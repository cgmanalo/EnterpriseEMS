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
        String RoomAddress;
        String DeviceAddress;
        String DeviceCommand;
        String DeviceReading;

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
                                                                    //Data_Field += '\0';
                                                                    //IncomingText.Text += '\0';
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
                //MessageBox.Show(Ex.Message);
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
                //MessageBox.Show(Ex.Message);
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
                    //int Delimiter_Position1 = Data_Field.IndexOf("|",0);
                    //RoomAddress = Data_Field.Substring(0,Delimiter_Position1);
                    //int Delimiter_Position2 = Data_Field.IndexOf("|", Delimiter_Position1 + 1);
                    //DeviceAddress = Data_Field.Substring(Delimiter_Position1 + 1, Delimiter_Position2 - Delimiter_Position1 - 1);
                    //DeviceCommand = Data_Field.Substring(Delimiter_Position2 + 1);
                    //int Delimiter_Position1 = Data_Field.IndexOf("|", 0);
                    DeviceAddress = Data_Field.Substring(0, Data_Field.IndexOf("|", 0));
                    switch (DeviceAddress)
                    {
                        
                        case "LIGHT1":
                            DeviceCommand = Data_Field.Substring(Data_Field.IndexOf("|", 0) + 1);
                            if (DeviceCommand == "ON")
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
                        case "ACU1A":
                            DeviceCommand = Data_Field.Substring(Data_Field.IndexOf("|", 0) + 1);
                            if (DeviceCommand == "ON")
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
                        case "ACU1B":
                            DeviceCommand = Data_Field.Substring(Data_Field.IndexOf("|", 0) + 1);
                            if (DeviceCommand == "ON")
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
                        case "PA1":
                            DeviceCommand = Data_Field.Substring(Data_Field.IndexOf("|", 0) + 1, Data_Field.IndexOf("|", Data_Field.IndexOf("|", 0) + 1) - Data_Field.IndexOf("|", 0) - 1);
                            DeviceReading = Data_Field.Substring(Data_Field.IndexOf("|", Data_Field.IndexOf("|", 0) + 1) + 1);
                            switch (DeviceCommand)
                            {
                                case "VOLT":
                                    LightVolt.Text = DeviceReading + " V";
                                    break;
                                case "CURR":
                                    LightAmps.Text = DeviceReading + " A";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "PA2":
                            DeviceCommand = Data_Field.Substring(Data_Field.IndexOf("|", 0) + 1, Data_Field.IndexOf("|", Data_Field.IndexOf("|", 0) + 1) - Data_Field.IndexOf("|", 0) - 1);
                            DeviceReading = Data_Field.Substring(Data_Field.IndexOf("|", Data_Field.IndexOf("|", 0) + 1) + 1); switch (DeviceCommand)
                            {
                                case "VOLT":
                                    ACU1AVolt.Text = DeviceReading + " V";
                                    break;
                                case "CURR":
                                    ACU1AAmps.Text = DeviceReading + " A";
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "PA3":
                            DeviceCommand = Data_Field.Substring(Data_Field.IndexOf("|", 0) + 1, Data_Field.IndexOf("|", Data_Field.IndexOf("|", 0) + 1) - Data_Field.IndexOf("|", 0) - 1);
                            DeviceReading = Data_Field.Substring(Data_Field.IndexOf("|", Data_Field.IndexOf("|", 0) + 1) + 1); switch (DeviceCommand)
                            {
                                case "VOLT":
                                    ACU1BVolt.Text = DeviceReading + " V";
                                    break;
                                case "CURR":
                                    ACU1BAmps.Text = DeviceReading + " A";
                                    break;
                                default:
                                    break;
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
                MessageBox.Show(Ex.Message);
            }
            TimerMain.Enabled = true;
        }

        private void LightButton_Click(object sender, EventArgs e)
        {
            if (LightButton.Text == "OFF") 
            {
                SerialPort.WriteLine("~~~LIGHT1|ON^^^");
                SerialPort.DiscardInBuffer();
            }
            else
            {
                SerialPort.WriteLine("~~~LIGHT1|OFF^^^");
                SerialPort.DiscardInBuffer();
            }
        }

        private void ACU1AButton_Click(object sender, EventArgs e)
        {
            if (ACU1AButton.Text == "OFF")
            {
                SerialPort.WriteLine("~~~ACU1A|ON^^^");
                SerialPort.DiscardInBuffer();
            }
            else
            {
                SerialPort.WriteLine("~~~ACU1A|OFF^^^");
                SerialPort.DiscardInBuffer();
            }
        }

        private void ACU1BButton_Click(object sender, EventArgs e)
        {
            if (ACU1BButton.Text == "OFF")
            {
                SerialPort.WriteLine("~~~ACU1B|ON^^^");
                SerialPort.DiscardInBuffer();
            }
            else
            {
                SerialPort.WriteLine("~~~ACU1B|OFF^^^");
                SerialPort.DiscardInBuffer();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            TimerMain.Enabled = false;
            if (Int16.Parse(EnrolledStudents.Text) > 15){
                SerialPort.WriteLine("~~~LIGHT1|ON^^^");
                Thread.Sleep(2000);
                SerialPort.WriteLine("~~~ACU1A|ON^^^");
                Thread.Sleep(2000);
                SerialPort.WriteLine("~~~ACU1B|ON^^^");
            }
            else
            {
                SerialPort.WriteLine("~~~LIGHT1|ON^^^");
                Thread.Sleep(2000);
                if (ACU1AButton.Text == "ON")
                {
                    SerialPort.WriteLine("~~~ACU1A|OFF^^^");
                    Thread.Sleep(2000);
                    SerialPort.WriteLine("~~~ACU1B|ON^^^");
                }
                else
                {
                    SerialPort.WriteLine("~~~ACU1A|ON^^^");
                    Thread.Sleep(2000);
                    SerialPort.WriteLine("~~~ACU1B|OFF^^^");
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

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LightVoltRead_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("~~~PA1|VOLT^^^");
        }

        private void LightAmpRead_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("~~~PA1|CURR^^^");
        }

        private void ACU1AVoltRead_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("~~~PA2|VOLT^^^");
        }

        private void ACU1AAmpRead_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("~~~PA2|CURR^^^");
        }

        private void ACU1BVoltRead_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("~~~PA3|VOLT^^^");
        }

        private void ACU1BAmpRead_Click(object sender, EventArgs e)
        {
            SerialPort.WriteLine("~~~PA3|CURR^^^");
        }
    }
}
