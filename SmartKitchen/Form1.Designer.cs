namespace SmartKitchen
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
            System.Environment.Exit(0);//这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GroupBoxSerialOperate = new System.Windows.Forms.GroupBox();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_CloseSerial = new System.Windows.Forms.Button();
            this.button_OpenSerial = new System.Windows.Forms.Button();
            this.button_SerialCheck = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_OTA = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_OTATarget = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBoxSerialOperate.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_OTA.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxSerialOperate
            // 
            this.GroupBoxSerialOperate.Controls.Add(this.button_Refresh);
            this.GroupBoxSerialOperate.Controls.Add(this.button_CloseSerial);
            this.GroupBoxSerialOperate.Controls.Add(this.button_OpenSerial);
            this.GroupBoxSerialOperate.Controls.Add(this.button_SerialCheck);
            this.GroupBoxSerialOperate.Controls.Add(this.label3);
            this.GroupBoxSerialOperate.Controls.Add(this.comboBox2);
            this.GroupBoxSerialOperate.Controls.Add(this.comboBox1);
            this.GroupBoxSerialOperate.Controls.Add(this.label2);
            this.GroupBoxSerialOperate.Controls.Add(this.label1);
            this.GroupBoxSerialOperate.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxSerialOperate.Name = "GroupBoxSerialOperate";
            this.GroupBoxSerialOperate.Size = new System.Drawing.Size(214, 328);
            this.GroupBoxSerialOperate.TabIndex = 0;
            this.GroupBoxSerialOperate.TabStop = false;
            this.GroupBoxSerialOperate.Text = "串口操作";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(110, 155);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(86, 43);
            this.button_Refresh.TabIndex = 7;
            this.button_Refresh.Text = "刷新";
            this.button_Refresh.UseVisualStyleBackColor = true;
            // 
            // button_CloseSerial
            // 
            this.button_CloseSerial.Location = new System.Drawing.Point(0, 249);
            this.button_CloseSerial.Name = "button_CloseSerial";
            this.button_CloseSerial.Size = new System.Drawing.Size(91, 42);
            this.button_CloseSerial.TabIndex = 6;
            this.button_CloseSerial.Text = "关闭串口";
            this.button_CloseSerial.UseVisualStyleBackColor = true;
            this.button_CloseSerial.Click += new System.EventHandler(this.button_CloseSerial_Click);
            // 
            // button_OpenSerial
            // 
            this.button_OpenSerial.Location = new System.Drawing.Point(0, 204);
            this.button_OpenSerial.Name = "button_OpenSerial";
            this.button_OpenSerial.Size = new System.Drawing.Size(91, 39);
            this.button_OpenSerial.TabIndex = 5;
            this.button_OpenSerial.Text = "打开串口";
            this.button_OpenSerial.UseVisualStyleBackColor = true;
            this.button_OpenSerial.Click += new System.EventHandler(this.button_OpenSerial_Click);
            // 
            // button_SerialCheck
            // 
            this.button_SerialCheck.Location = new System.Drawing.Point(0, 155);
            this.button_SerialCheck.Name = "button_SerialCheck";
            this.button_SerialCheck.Size = new System.Drawing.Size(91, 43);
            this.button_SerialCheck.TabIndex = 1;
            this.button_SerialCheck.Text = "串口检测";
            this.button_SerialCheck.UseVisualStyleBackColor = true;
            this.button_SerialCheck.Click += new System.EventHandler(this.button_SerialCheck_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "串口状态：断开";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(79, 72);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(117, 23);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TCP/UDP"});
            this.comboBox1.Location = new System.Drawing.Point(79, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口号：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_OTA);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(243, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(903, 589);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage_OTA
            // 
            this.tabPage_OTA.Controls.Add(this.label12);
            this.tabPage_OTA.Controls.Add(this.textBox5);
            this.tabPage_OTA.Controls.Add(this.label11);
            this.tabPage_OTA.Controls.Add(this.label10);
            this.tabPage_OTA.Controls.Add(this.textBox4);
            this.tabPage_OTA.Controls.Add(this.label9);
            this.tabPage_OTA.Controls.Add(this.label8);
            this.tabPage_OTA.Controls.Add(this.label7);
            this.tabPage_OTA.Controls.Add(this.button2);
            this.tabPage_OTA.Controls.Add(this.progressBar1);
            this.tabPage_OTA.Controls.Add(this.textBox3);
            this.tabPage_OTA.Controls.Add(this.label6);
            this.tabPage_OTA.Controls.Add(this.textBox2);
            this.tabPage_OTA.Controls.Add(this.label5);
            this.tabPage_OTA.Controls.Add(this.label4);
            this.tabPage_OTA.Controls.Add(this.textBox1);
            this.tabPage_OTA.Controls.Add(this.button1);
            this.tabPage_OTA.Controls.Add(this.label_OTATarget);
            this.tabPage_OTA.Controls.Add(this.comboBox3);
            this.tabPage_OTA.Location = new System.Drawing.Point(4, 25);
            this.tabPage_OTA.Name = "tabPage_OTA";
            this.tabPage_OTA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_OTA.Size = new System.Drawing.Size(895, 560);
            this.tabPage_OTA.TabIndex = 0;
            this.tabPage_OTA.Text = "OTA";
            this.tabPage_OTA.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(497, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 19);
            this.label12.TabIndex = 24;
            this.label12.Text = "用时：0s";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(89, 44);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(101, 25);
            this.textBox5.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "帧头：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "日志：";
            // 
            // textBox4
            // 
            this.textBox4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox4.Location = new System.Drawing.Point(19, 349);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox4.Size = new System.Drawing.Size(861, 205);
            this.textBox4.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "填充后大小：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "源文件大小：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(794, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "0%";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 200);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 47);
            this.button2.TabIndex = 16;
            this.button2.Text = "开始升级";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 265);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(741, 38);
            this.progressBar1.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(788, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(92, 25);
            this.textBox3.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(700, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "软件版本：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(567, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 25);
            this.textBox2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "硬件版本：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "路径：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(100, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(660, 25);
            this.textBox1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 8;
            this.button1.Text = "打开文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_OTATarget
            // 
            this.label_OTATarget.AutoSize = true;
            this.label_OTATarget.Location = new System.Drawing.Point(264, 50);
            this.label_OTATarget.Name = "label_OTATarget";
            this.label_OTATarget.Size = new System.Drawing.Size(67, 15);
            this.label_OTATarget.TabIndex = 3;
            this.label_OTATarget.Text = "目标板：";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "微波炉",
            "1号烤箱",
            "2号烤箱",
            "冰箱",
            "主控板",
            "电源板"});
            this.comboBox3.Location = new System.Drawing.Point(337, 47);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(117, 23);
            this.comboBox3.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(895, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "功能区";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 642);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.GroupBoxSerialOperate);
            this.Name = "Form1";
            this.Text = "SmartKitchen  By昂20211126";
            this.GroupBoxSerialOperate.ResumeLayout(false);
            this.GroupBoxSerialOperate.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_OTA.ResumeLayout(false);
            this.tabPage_OTA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxSerialOperate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CloseSerial;
        private System.Windows.Forms.Button button_OpenSerial;
        private System.Windows.Forms.Button button_SerialCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_OTA;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_OTATarget;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

