using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LuaInterface;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace msg_window
{
    static class main
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        [DllImport("Utils", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Bin2Json(int type, byte[] bin_data, int len, byte[] json_buffer);
    }
}
