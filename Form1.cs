using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using LuaInterface;

namespace msg_window
{
    struct Msg
    {
        public int type;
        public string content;
    }

    delegate void UiDelegate();

    public partial class Form1 : Form
    {
        Lua L = new Lua();

        UdpClient udp_for_received = new UdpClient(10001);
        UdpClient udp_for_sent = new UdpClient(10002);

        Dictionary<int, string> types = new Dictionary<int, string>();

        const int kMaxMsgs = 250;

        List<Msg> msgs = new List<Msg>();

        bool locked = false; //锁定当前消息，不被刷新

        private Socket m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public Form1()
        {
            InitializeComponent();
            InitializeMsgKey();
            udp_for_received.BeginReceive(OnUdpDataGot, false);
            udp_for_sent.BeginReceive(OnUdpDataGot, true);
        }

        private void InitializeMsgKey()
        {
            L.DoFile("../../Assets/LuaFramework/Lua/network/MsgWindowdef.lua");
            LuaTable tbl = L.GetTable("tbl");
            foreach (string key in tbl.Keys)
            {
                try
                {
                    types[Convert.ToInt32(tbl[key])] = (string)key;
                }
                catch (System.Exception ex)
                {

                }
            }
        }

        string Type2Text(int type, bool is_sent)
        {
            string ret = types[type] == null ? type.ToString() : types[type].ToString();
            ret = ret + "   " + string.Format("{0}:{1}:{2}.{3}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            ret = is_sent ? "↑   " + ret : "↓   " + ret;
            return ret;
        }

        void OnUdpDataGot(IAsyncResult ar)
        {
            bool is_sent = (bool)ar.AsyncState;
            IPEndPoint ep = null;
            byte[] data;
            if (is_sent)
            {
                data = udp_for_sent.EndReceive(ar, ref ep);
                udp_for_sent.BeginReceive(OnUdpDataGot, true);
            }
            else
            {
                data = udp_for_received.EndReceive(ar, ref ep);
                udp_for_received.BeginReceive(OnUdpDataGot, false);
            }

            if (locked) return;
            int type = BitConverter.ToInt32(data, 0);
            int lens = BitConverter.ToInt32(data, 4);
            string content = Encoding.UTF8.GetString(data, 8, data.Length - 8);

            UiDelegate w = () =>
            {
                Msg msg;
                msg.type = type;
                msg.content = content;
                try
                {
                    if (msgs.Count >= kMaxMsgs)
                    {
                        msgs.RemoveAt(0);
                        list_msg.Items.RemoveAt(0);
                    }
                }
                catch (System.Exception ex)
                {

                }

                msgs.Add(msg);
                list_msg.Items.Add(Type2Text(type, is_sent));
                list_msg.SelectedIndex = list_msg.Items.Count - 1;
            };
            list_msg.Invoke(w);
        }

        private void list_msg_SelectedIndexChanged(object sender, EventArgs e)
        {
            var msg = msgs[list_msg.SelectedIndex];
            json_viewer.Json = msg.content;
        }

        private void button_lock_Click(object sender, EventArgs e)
        {
            if (!locked)
            {
                locked = true;
                button_lock.Text = "解锁";
            }
            else
            {
                locked = false;
                button_lock.Text = "锁定";
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            msgs.Clear();
            list_msg.Items.Clear();
            json_viewer.Json = "";
        }

        private void ButtonSend2ClientClick(object sender, EventArgs e)
        {
            if (CheckStringNullOrEmpty()) return;
            int msg_id = GetMsgId();
            string info = this.msg_info_box.Text;
            Console.WriteLine(msg_id);
            Console.WriteLine(info);
            if (msg_id == 0) return;
            SendInfo(info, 10003, msg_id);
        }
        private bool CheckStringNullOrEmpty()
        {
            return String.IsNullOrEmpty(this.msg_id_box.Text) || String.IsNullOrEmpty(this.msg_info_box.Text);
        }
        private int GetMsgId()
        {
            int id = 0;
            bool match = false;
            int.TryParse(this.msg_id_box.Text, out id);
            foreach (KeyValuePair<int, string> kvp in types)
            {
                if (kvp.Value == this.msg_id_box.Text || kvp.Key == id)
                {
                    match = true;
                    id = kvp.Key;
                    break;
                }
            }
            if (match == true)
            {
                this.label3.Text = "";
                return id;
            }
            else
            {
                this.label3.Text = "消息错误";
                return 0;
            }
        }
        private void SendInfo(string buff, int port, int op)
        {
            //定义网络地址  
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            //发送数据  
            EndPoint ep = (EndPoint)iep;
            List<byte> msg = new List<byte>();
            msg.AddRange(BitConverter.GetBytes(true));
            msg.AddRange(BitConverter.GetBytes(op));
            byte[] str = Encoding.UTF8.GetBytes(buff);
            msg.AddRange(BitConverter.GetBytes(str.Length));
            msg.AddRange(str);
            //发送  
            if (m_socket != null)
                m_socket.SendTo(msg.ToArray(), ep);
        }
    }
}
