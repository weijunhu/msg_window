namespace msg_window
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.json_viewer = new EPocalipse.Json.Viewer.JsonViewer();
            this.list_msg = new System.Windows.Forms.ListBox();
            this.button_lock = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_send2client = new System.Windows.Forms.Button();
            this.msg_id_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msg_info_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // json_viewer
            // 
            this.json_viewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.json_viewer.Json = null;
            this.json_viewer.Location = new System.Drawing.Point(285, 40);
            this.json_viewer.Name = "json_viewer";
            this.json_viewer.Size = new System.Drawing.Size(557, 292);
            this.json_viewer.TabIndex = 2;
            // 
            // list_msg
            // 
            this.list_msg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.list_msg.FormattingEnabled = true;
            this.list_msg.ItemHeight = 12;
            this.list_msg.Location = new System.Drawing.Point(10, 40);
            this.list_msg.Name = "list_msg";
            this.list_msg.Size = new System.Drawing.Size(270, 292);
            this.list_msg.TabIndex = 1;
            this.list_msg.SelectedIndexChanged += new System.EventHandler(this.list_msg_SelectedIndexChanged);
            // 
            // button_lock
            // 
            this.button_lock.Location = new System.Drawing.Point(87, 2);
            this.button_lock.Name = "button_lock";
            this.button_lock.Size = new System.Drawing.Size(65, 34);
            this.button_lock.TabIndex = 3;
            this.button_lock.Text = "锁定";
            this.button_lock.UseVisualStyleBackColor = true;
            this.button_lock.Click += new System.EventHandler(this.button_lock_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(12, 2);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(65, 34);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "清空";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_send2client
            // 
            this.button_send2client.Location = new System.Drawing.Point(13, 354);
            this.button_send2client.Name = "button_send2client";
            this.button_send2client.Size = new System.Drawing.Size(80, 34);
            this.button_send2client.TabIndex = 5;
            this.button_send2client.Text = "给客户端发消息";
            this.button_send2client.UseVisualStyleBackColor = true;
            this.button_send2client.Click += new System.EventHandler(this.ButtonSend2ClientClick);
            // 
            // msg_id_box
            // 
            this.msg_id_box.Location = new System.Drawing.Point(158, 362);
            this.msg_id_box.Name = "msg_id_box";
            this.msg_id_box.Size = new System.Drawing.Size(263, 21);
            this.msg_id_box.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "消息id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "消息内容";
            // 
            // msg_info_box
            // 
            this.msg_info_box.Location = new System.Drawing.Point(10, 435);
            this.msg_info_box.Multiline = true;
            this.msg_info_box.Name = "msg_info_box";
            this.msg_info_box.Size = new System.Drawing.Size(880, 99);
            this.msg_info_box.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 654);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 546);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.msg_info_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msg_id_box);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_lock);
            this.Controls.Add(this.list_msg);
            this.Controls.Add(this.json_viewer);
            this.Controls.Add(this.button_send2client);
            this.Name = "Form1";
            this.Text = "灵能消息查看器";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EPocalipse.Json.Viewer.JsonViewer json_viewer;
        private System.Windows.Forms.ListBox list_msg;
        private System.Windows.Forms.Button button_lock;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_send2client;
        private System.Windows.Forms.TextBox msg_id_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msg_info_box;
        private System.Windows.Forms.Label label3;

    }
}

