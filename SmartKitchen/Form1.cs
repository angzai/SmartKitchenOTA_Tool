using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace SmartKitchen
{
    public partial class Form1 : Form
    {
        public static SerialPort sp = new SerialPort();
        string fileName;    //需要升级的文件名字 包含了绝对路径
        byte[] HexFile;         //读取出来的hex文件
        byte[] OTA_Data= new byte[65535];          //经过填充后的升级数据文件
        byte address;
        ushort flashAddress;
        byte hardware;
        byte firmware;
        ushort frameNumYu;
        ushort frameNum;   //需要升级的帧的数量
        string[] serialPorts = SerialPort.GetPortNames();
        //byte[] a = new byte[150];//读出缓冲区串口通信的字节
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//设置该属性 为false
        }

        private void button_SerialCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPorts.Length != 0)
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(serialPorts);
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("未检测到端口");
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(new object[] { "default", "tcp/udp" });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_OpenSerial_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen == true)
            {
                MessageBox.Show("串口已经打开");
            }
            else
            {
                try
                {
                    if (serialPorts.Length != 0)
                    {
                        sp.PortName = comboBox1.SelectedItem.ToString();
                        sp.BaudRate = Convert.ToInt32(comboBox2.SelectedItem);
                        sp.DataBits = 8;
                        sp.Parity = Parity.None;
                        sp.StopBits = StopBits.One;
                        sp.Open();
                        label3.Text = "串口状态：已连接";
                        label3.ForeColor = System.Drawing.Color.Green;
                        //Thread thread = new Thread(Get_CafeState);
                        //thread.Start();//启动新线程
                    }
                    else
                    {
                        MessageBox.Show("未检测到端口");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button_CloseSerial_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen != true)
            {
                label3.Text = "串口状态：断开";
                label3.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("串口已经关闭");
            }
            else
            {
                try
                {
                    sp.Close();           
                    label3.Text = "串口状态：断开";
                    label3.ForeColor = System.Drawing.Color.Red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;//该值确定是否可以选择多个文件
            openFileDialog.Title = "请选择用于OTA升级的bin文件";
            //openFileDialog.Filter = "所有文件(*.*)|*.*";
            openFileDialog.Filter = "bin文件|*.bin";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                HexFile=ReadBinFile(fileName);
                textBox1.Text = fileName;
                label8.Text = "源文件大小：" + Convert.ToString(HexFile.Length)+"字节";
                frameNumYu = Convert.ToUInt16(HexFile.Length % 128);
                if (frameNumYu != 0)
                {
                    int length = (HexFile.Length / 128 + 1) * 128;
                    label9.Text = "填充后大小：" + Convert.ToString(length) + "字节";
                    frameNum = Convert.ToUInt16(HexFile.Length / 128 + 1);
                }
                else
                {
                    label9.Text = "填充后大小：" + Convert.ToString(HexFile.Length) + "字节";
                    frameNum = Convert.ToUInt16(HexFile.Length / 128) ;
                }

                textBox4.AppendText("打开bin文件成功\r\n");

                progressBar1.Maximum = frameNum * 128;

                openFileDialog.Dispose();
            }
        }

        /*
         *  将文件流读取为字节流，便于升级时数据传输
         */
        static byte[] ReadBinFile(string FileNameWithPath)
        {
            //从指定的目录以打开或创建的形式读取日志文件
            FileStream fs = new FileStream(FileNameWithPath, FileMode.OpenOrCreate, FileAccess.Read);

            byte[] Binfile = new byte[(int)fs.Length];

            fs.Read(Binfile, 0, Binfile.Length);

            fs.Close();

            return Binfile;

            ////定义输出字符串
            //StringBuilder output = new StringBuilder();

            ////初始化该字符串的长度为0
            //output.Length = 0;

            ////为上面创建的文件流创建读取数据流
            //StreamReader read = new StreamReader(fs);

            ////设置当前流的起始位置为文件流的起始点
            //read.BaseStream.Seek(0, SeekOrigin.Begin);

            ////读取文件
            //while (read.Peek() > -1)
            //{
            //    //取文件的一行内容并换行
            //    output.Append(read.ReadLine() + "\n");
            //}

            ////关闭释放读数据流
            //read.Close();
            ////返回读到的日志文件内容
            //return output.ToString();
        }

        /*
         *  开始升级，并创建一个线程用于升级过程传输数据
         */
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.SelectedItem.Equals("微波炉"))
                {
                    address = 0x01;
                }
                else if (comboBox3.SelectedItem.Equals("1号烤箱"))
                {
                    address = 0x02;
                }
                else if (comboBox3.SelectedItem.Equals("2号烤箱"))
                {
                    address = 0x03;
                }
                else if (comboBox3.SelectedItem.Equals("冰箱"))
                {
                    address = 0x04;
                }
                else if (comboBox3.SelectedItem.Equals("主控板"))
                {
                    address = 0x05;
                }
                else if (comboBox3.SelectedItem.Equals("电源板"))
                {
                    address = 0x06;
                }

                firmware = Convert.ToByte(textBox3.Text);
                hardware = Convert.ToByte(textBox2.Text);

                for (ushort i = 0; i < HexFile.Length; i++)
                {
                    OTA_Data[i] = HexFile[i];
                }
                if(frameNumYu != 0)
                {
                    for (ushort i = (ushort)HexFile.Length; i < (frameNum * 128); i++)
                    {
                        OTA_Data[i] = 0xFF;
                    }
                }


                Thread thread = new Thread(Start_OTA);
                thread.Start();//启动新线程
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Start_OTA()
        {
            byte[] CMD_Byte = { 0xFE, 0x0E, 0x00,0x01,0x00,0x05,0x00,0x00,0x00,0x00,0x00,0x00,0x00};
            try
            {
                CMD_Byte[2] = address;

                CMD_Byte[6] = Convert.ToByte(Convert.ToUInt16(frameNum*128) >> 8);
                CMD_Byte[7] = Convert.ToByte(Convert.ToUInt16(frameNum*128)&0x00ff);



                for (uint i=0;i< HexFile.Length; i++)
                {
                    CMD_Byte[8] += HexFile[i];                 
                }
                if (frameNumYu != 0)
                {
                    for (ushort i = (ushort)HexFile.Length; i < (frameNum * 128); i++)
                    {
                        CMD_Byte[8] += 0xFF;
                    }
                }

                CMD_Byte[9] = firmware;
                CMD_Byte[10] = hardware;

                uint crc16 = crc16_modbus(CMD_Byte, 11);
                CMD_Byte[11] = Convert.ToByte(crc16>>8);
                CMD_Byte[12] = Convert.ToByte(crc16&0x00ff);

                Boolean isStop = true;
                while (isStop)
                {
                    sp.DiscardInBuffer();
                    sp.Write(CMD_Byte,0, CMD_Byte.Length);
                    textBox4.AppendText("发送升级准备请求\r\n");
                    System.Threading.Thread.Sleep(800);

                    byte[] a = new byte[20];
                    sp.Read(a,0,a.Length);
                    textBox4.AppendText("接收升级准备响应\r\n");
                    if (a[0]==0xfe)
                    {
                        if (a[5] == 0x01)  //允许升级
                        {
                            progressBar1.Value = 10;
                            label7.Text = "升级准备中";
                            textBox4.AppendText("升级准备过程完成，准备进入数据传输阶段 \r\n");
                             
                            Thread thread = new Thread(OTA_TransmitData);
                            thread.Start();//启动新线程v

                            isStop = false;
                            
                        }
                        else
                        {
                            if(a[5] == 0x02)
                            {
                                MessageBox.Show("硬件版本号错误 \r\n");
                                //textBox4.AppendText("硬件版本号错误 \r\n");
                            }
                            else if(a[5] == 0x03)
                            {
                                MessageBox.Show("软件已经是最新版本 \r\n");
                                //textBox4.AppendText("软件已经是最新版本 \r\n");
                            }
                            
                            isStop = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                System.Threading.Thread.CurrentThread.Abort();
                MessageBox.Show(ex.Message);
            }

        }
        public void OTA_TransmitData()
        {
            byte[] CMD_Byte = new byte[138];
            ushort i = 0;
            try
            {
                CMD_Byte[0] = 0xfe;
                CMD_Byte[1] = 0x0e;
                CMD_Byte[2] = address;
                CMD_Byte[3] = 0x02;
                CMD_Byte[4] = 0x00;
                CMD_Byte[5] = 0x82;

                Boolean isStop = true;
                while (isStop)
                {
                    flashAddress = Convert.ToUInt16(i * 128);
                    CMD_Byte[6] = Convert.ToByte(flashAddress >> 8);
                    CMD_Byte[7] = Convert.ToByte(flashAddress & 0x00ff);
                    for (byte j = 8; j < (128 + 8); j++)
                    {
                        CMD_Byte[j] = OTA_Data[(j - 8) + i * 128];
                    }

                    uint crc16 = crc16_modbus(CMD_Byte, 136);
                    CMD_Byte[136] = Convert.ToByte(crc16 >> 8);
                    CMD_Byte[137] = Convert.ToByte(crc16 & 0x00ff);

                    sp.DiscardInBuffer();
                    sp.Write(CMD_Byte, 0, CMD_Byte.Length);
                    System.Threading.Thread.Sleep(800);
                    byte[] a = new byte[20];
                    sp.Read(a, 0, a.Length);
                    textBox4.AppendText("发送帧序号："+ Convert.ToString(i)+"\r\n");
                    for (byte k=0;k< CMD_Byte.Length; k++)
                    {
                        textBox4.AppendText("0x"+CMD_Byte[k].ToString("X2") + " ");
                    }
                    textBox4.AppendText( "\r\n");
                    if (a[0] == 0xfe)
                    {
                        if (a[5] == 0x01)
                        {
                            progressBar1.Value = i * 128+128;
                            label7.Text = Convert.ToString(((float)progressBar1.Value) / ((float)progressBar1.Maximum) * 100) + "%";

                            if (i >= (frameNum-1))
                            {

                                textBox4.Text = textBox4.Text + "数据传输完成，开始确认是否升级 \r\n";
                                Thread thread = new Thread(OTA_Confirm);
                                thread.Start();//启动新线程v

                                isStop = false;
                            }

                            i++;
                        }
                        else
                        {
                            if (a[5] == 0x02)
                            {
                                MessageBox.Show("起始地址超出芯片flash，中止升级 \r\n");
                            }
                            else if (a[5] == 0x03)
                            {
                                MessageBox.Show("其他原因 \r\n");
                            }

                            isStop = false;
                        }
                    }
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void OTA_Confirm()
        {
            byte[] CMD_Byte = new byte[8];

            CMD_Byte[0] = 0xfe;
            CMD_Byte[1] = 0x0e;
            CMD_Byte[2] = address;
            CMD_Byte[3] = 0x03;
            CMD_Byte[4] = 0x00;
            CMD_Byte[5] = 0x00;

            uint crc16 = crc16_modbus(CMD_Byte, 6);
            CMD_Byte[6] = Convert.ToByte(crc16 >> 8);
            CMD_Byte[7] = Convert.ToByte(crc16 & 0x00ff);

            Boolean isStop = true;
            while (isStop)
            {
                sp.DiscardInBuffer();
                sp.Write(CMD_Byte, 0, CMD_Byte.Length);
                System.Threading.Thread.Sleep(800);

                byte[] a = new byte[20];
                sp.Read(a, 0, a.Length);
                if (a[0]==0xfe)
                {
                    if (a[5] == 0x01)
                    {
                        textBox4.AppendText("确认完成，固件正在重启 \r\n");

                        isStop = false;
                    }
                    else
                    {
                        if (a[5] == 0x02)
                        {
                            MessageBox.Show("bin数据和校验不通过 \r\n");
                        }
                        else if (a[5] == 0x03)
                        {
                            MessageBox.Show("bin数据长度错误 \r\n");
                        }

                        isStop = false;
                    }
                }
            }
        }
        public uint crc16_modbus(byte[] modbusdata, uint length)
        {
            uint i, j;
            uint crc16 = 0xffff;
            for (i = 0; i < length; i++)
            {
                crc16 ^= modbusdata[i];
                for (j = 0; j < 8; j++)
                {
                    if ((crc16 & 0x01) == 1)
                    {
                        crc16 = (crc16 >> 1) ^ 0xA001;
                    }
                    else
                    {
                        crc16 = crc16 >> 1;
                    }
                }
            }
            return crc16;
        }
    }
}
