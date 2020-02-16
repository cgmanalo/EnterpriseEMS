using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace EMS_Gateway
{
    public partial class MainForm : Form
    {
        int CountDown1;
        int CountDown2;
        String Data_Field;
        char Data_Char;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetPortList();
            Connect.Text = "Connect";
            //RTS.Enabled = false;
            Send.Enabled = false;
            LightButton.Enabled = false;
            ACU1AButton.Enabled = false;
            ACU1BButton.Enabled = false;
            Update.Enabled = false;
        }
        private void GetPortList()
        {
            try
            {
                string[] portListing = System.IO.Ports.SerialPort.GetPortNames();
                PortList.Items.Clear();

                foreach (string portName in portListing)
                {
                    PortList.Items.Add(portName);
                }
                PortList.SelectedIndex = 0;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message,"General Port Error");
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
                Connect.Text = "Connect";
                TimerMain.Enabled = false;
                Send.Enabled = false;
                LightButton.Enabled = false;
                ACU1AButton.Enabled = false;
                ACU1BButton.Enabled = false;
                Update.Enabled = false;
                //groupA.Enabled = false;
                //groupB.Enabled = false;
                //RTS.Enabled = false;
                //SerialPort.RtsEnable = false;
                //Timer.Enabled = false;
            }
            else
            {
                SerialPort.PortName = PortList.Text;
                SerialPort.Open();
                Connect.Text = "Disconnect";
                TimerMain.Enabled = true;
                Send.Enabled = true;
                LightButton.Enabled = true;
                ACU1AButton.Enabled = true;
                ACU1BButton.Enabled = true;
                Update.Enabled = true;
                //groupA.Enabled = true;
                //groupB.Enabled = true;
                //RTS.Enabled = true;
                //if (RTS.Checked == true)
                //{
                //    SerialPort.RtsEnable = true; //transmit only
                //}
                //else
                //{
                //    SerialPort.RtsEnable = false; //transmit/receive
                //}
                //Timer.Enabled = true;
            }
        }

        private bool GetSerialData()
        {
            try
            {
                SerialPort.ReadTimeout = 2000;
                CountDown1 = 10;
                Timer1.Enabled = true;
                while (CountDown1 > 0)
                {
                    Application.DoEvents();
                    if ((Char)SerialPort.ReadChar() == '~')
                    {
                        CountDown1 = 10;
                        while (CountDown1 > 0)
                        {
                            Application.DoEvents();
                            if ((Char)SerialPort.ReadChar() == '~')
                            {
                                CountDown1 = 10;
                                while (CountDown1 > 0)
                                {
                                    Application.DoEvents();
                                    if ((Char)SerialPort.ReadChar() == '~')
                                    {
                                        Data_Field = "";
                                        CountDown2 = 300;
                                        while (CountDown2 > 0)
                                        {
                                            Application.DoEvents();
                                            CountDown1 = 10;
                                            while (CountDown1 > 0)
                                            {
                                                Application.DoEvents();
                                                Data_Char = (Char)SerialPort.ReadChar();
                                                if(Data_Char == '^')
                                                {
                                                    CountDown1 = 10;
                                                    while (CountDown1 > 0)
                                                    {
                                                        Application.DoEvents();
                                                        Data_Char = (Char)SerialPort.ReadChar();
                                                        if(Data_Char == '^')
                                                        {
                                                            CountDown1 = 10;
                                                            while (CountDown1 > 0)
                                                            {
                                                                Application.DoEvents();
                                                                Data_Char = (Char)SerialPort.ReadChar();
                                                                if(Data_Char == '^')
                                                                {
                                                                    Data_Field += '\0';
                                                                    IncomingText.Text += '\0';
                                                                    return true;
                                                                }
                                                                else
                                                                {
                                                                    Data_Field += Data_Char;
                                                                    IncomingText.Text += Data_Char;
                                                                }
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Data_Field += Data_Char;
                                                            IncomingText.Text += Data_Char;
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Data_Field += Data_Char;
                                                    IncomingText.Text += Data_Char;
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
                Timer1.Enabled = false;
            }
            catch(Exception Ex)
            {
             //   MessageBox.Show(Ex.Message);
            }
            return false;
        }
        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort.WriteLine(Command.Text);
                SerialPort.DiscardInBuffer();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CountDown1 > 0) { CountDown1--; }
            if (CountDown2 > 0) { CountDown2--; }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (CountDown2 > 0) { CountDown2--; }
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            
            TimerMain.Enabled = false;
            try
            {
                if (GetSerialData())
                {
                    String RoomAddress = Data_Field.Substring(0,1);
                    String DeviceAddress = Data_Field.Substring(1,1);
                    String DeviceCommand = Data_Field.Substring(2,1);
                    switch (DeviceAddress)
                    {
                        case "1":
                            if (DeviceCommand == "1")
                            {
                                LightButton.Text = "ON";
                                LightButton.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                LightButton.Text = "OFF";
                                LightButton.BackColor = Color.Red;
                            }
                            break;
                        case "2":
                            if (DeviceCommand == "1")
                            {
                                ACU1AButton.Text = "ON";
                                ACU1AButton.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                ACU1AButton.Text = "OFF";
                                ACU1AButton.BackColor = Color.Red;
                            }
                            break;
                        case "3":
                            if (DeviceCommand == "1")
                            {
                                ACU1BButton.Text = "ON";
                                ACU1BButton.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                ACU1BButton.Text = "OFF";
                                ACU1BButton.BackColor = Color.Red;
                            }
                            break;
                        case "Q":
                            switch (DeviceCommand)
                            {
                                case "0":
                                    LightButton.Text = "OFF";
                                    ACU1AButton.Text = "OFF";
                                    ACU1BButton.Text = "OFF";
                                    LightButton.BackColor = Color.Red;
                                    ACU1AButton.BackColor = Color.Red;
                                    ACU1BButton.BackColor = Color.Red;
                                    break;
                                case "1":
                                    LightButton.Text = "ON";
                                    ACU1AButton.Text = "OFF";
                                    ACU1BButton.Text = "OFF";
                                    LightButton.BackColor = Color.LightGreen;
                                    ACU1AButton.BackColor = Color.Red;
                                    ACU1BButton.BackColor = Color.Red;
                                    break;
                                case "2":
                                    LightButton.Text = "OFF";
                                    ACU1AButton.Text = "ON";
                                    ACU1BButton.Text = "OFF";
                                    LightButton.BackColor = Color.Red;
                                    ACU1AButton.BackColor = Color.LightGreen;
                                    ACU1BButton.BackColor = Color.Red;
                                    break;
                                case "3":
                                    LightButton.Text = "ON";
                                    ACU1AButton.Text = "ON";
                                    ACU1BButton.Text = "OFF";
                                    LightButton.BackColor = Color.LightGreen;
                                    ACU1AButton.BackColor = Color.LightGreen;
                                    ACU1BButton.BackColor = Color.Red;
                                    break;
                                case "4":
                                    LightButton.Text = "OFF";
                                    ACU1AButton.Text = "OFF";
                                    ACU1BButton.Text = "ON";
                                    LightButton.BackColor = Color.Red;
                                    ACU1AButton.BackColor = Color.Red;
                                    ACU1BButton.BackColor = Color.LightGreen;
                                    break;
                                case "5":
                                    LightButton.Text = "ON";
                                    ACU1AButton.Text = "OFF";
                                    ACU1BButton.Text = "ON";
                                    LightButton.BackColor = Color.LightGreen;
                                    ACU1AButton.BackColor = Color.Red;
                                    ACU1BButton.BackColor = Color.LightGreen;
                                    break;
                                case "6":
                                    LightButton.Text = "OFF";
                                    ACU1AButton.Text = "ON";
                                    ACU1BButton.Text = "ON";
                                    LightButton.BackColor = Color.Red;
                                    ACU1AButton.BackColor = Color.LightGreen;
                                    ACU1BButton.BackColor = Color.LightGreen;
                                    break;
                                case "7":
                                    LightButton.Text = "ON";
                                    ACU1AButton.Text = "ON";
                                    ACU1BButton.Text = "ON";
                                    LightButton.BackColor = Color.LightGreen;
                                    ACU1AButton.BackColor = Color.LightGreen;
                                    ACU1BButton.BackColor = Color.LightGreen;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            catch(Exception Ex)
            {
                TimerMain.Enabled = true;
                //MessageBox.Show(Ex.Message);
            }
            TimerMain.Enabled = true;
        }

        private void LightButton_Click(object sender, EventArgs e)
        {
            if (LightButton.Text == "OFF") 
            {
                SerialPort.WriteLine("~~~A11^^^");
                SerialPort.DiscardInBuffer();
            }
            else
            {
                SerialPort.WriteLine("~~~A10^^^");
                SerialPort.DiscardInBuffer();
            }
        }

        private void ACU1AButton_Click(object sender, EventArgs e)
        {
            if (ACU1AButton.Text == "OFF")
            {
                SerialPort.WriteLine("~~~A21^^^");
                SerialPort.DiscardInBuffer();
            }
            else
            {
                SerialPort.WriteLine("~~~A20^^^");
                SerialPort.DiscardInBuffer();
            }
        }

        private void ACU1BButton_Click(object sender, EventArgs e)
        {
            if (ACU1BButton.Text == "OFF")
            {
                SerialPort.WriteLine("~~~A31^^^");
                SerialPort.DiscardInBuffer();
            }
            else
            {
                SerialPort.WriteLine("~~~A30^^^");
                SerialPort.DiscardInBuffer();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            TimerMain.Enabled = false;
            if (Int16.Parse(EnrolledStudents.Text) > 15){
                SerialPort.WriteLine("~~~A11^^^");
                Thread.Sleep(2000);
                SerialPort.WriteLine("~~~A21^^^");
                Thread.Sleep(2000);
                SerialPort.WriteLine("~~~A31^^^");
            }
            else
            {
                SerialPort.WriteLine("~~~A11^^^");
                Thread.Sleep(2000);
                if (ACU1AButton.Text == "ON")
                {
                    SerialPort.WriteLine("~~~A20^^^");
                    Thread.Sleep(2000);
                    SerialPort.WriteLine("~~~A31^^^");
                }
                else
                {
                    SerialPort.WriteLine("~~~A21^^^");
                    Thread.Sleep(2000);
                    SerialPort.WriteLine("~~~A30^^^");
                }
            }
            TimerMain.Enabled = true;
        }

        private void ClearText_Click(object sender, EventArgs e)
        {
            IncomingText.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
