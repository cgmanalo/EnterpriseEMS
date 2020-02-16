namespace EMS_Gateway
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Connect = new System.Windows.Forms.Button();
            this.PortList = new System.Windows.Forms.ComboBox();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.Send = new System.Windows.Forms.Button();
            this.Command = new System.Windows.Forms.ComboBox();
            this.EMSLabel = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.IncomingText = new System.Windows.Forms.TextBox();
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.RoomA = new System.Windows.Forms.GroupBox();
            this.Update = new System.Windows.Forms.Button();
            this.EnrolledStudents = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.ACU1BAmpRead = new System.Windows.Forms.Button();
            this.ACU1BVoltRead = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.ACU1AAmpRead = new System.Windows.Forms.Button();
            this.ACU1AVoltRead = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.LightAmpRead = new System.Windows.Forms.Button();
            this.LightVoltRead = new System.Windows.Forms.Button();
            this.ACU1BButton = new System.Windows.Forms.Button();
            this.ACU1AButton = new System.Windows.Forms.Button();
            this.LightButton = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ACU1BAmps = new System.Windows.Forms.Label();
            this.ACU1AAmps = new System.Windows.Forms.Label();
            this.LightAmps = new System.Windows.Forms.Label();
            this.ACU1BVolt = new System.Windows.Forms.Label();
            this.ACU1AVolt = new System.Windows.Forms.Label();
            this.LightVolt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearText = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RoomA.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            // 
            // Connect
            // 
            this.Connect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Connect.Location = new System.Drawing.Point(45, 68);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 1;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // PortList
            // 
            this.PortList.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PortList.FormattingEnabled = true;
            this.PortList.Location = new System.Drawing.Point(140, 68);
            this.PortList.Name = "PortList";
            this.PortList.Size = new System.Drawing.Size(230, 21);
            this.PortList.TabIndex = 2;
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Send.Location = new System.Drawing.Point(45, 108);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 3;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Command
            // 
            this.Command.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Command.FormattingEnabled = true;
            this.Command.Items.AddRange(new object[] {
            "~~~LIGHT1|ON^^^",
            "~~~LIGHT1|OFF^^^",
            "~~~LIGHT1|TOG^^^",
            "~~~ACU1A|ON^^^",
            "~~~ACU1A|OFF^^^",
            "~~~ACU1A|TOG^^^",
            "~~~ACU1B|ON^^^",
            "~~~ACU1B|OFF^^^",
            "~~~ACU1B|TOG^^^",
            "~~~PA1|VOLT^^^",
            "~~~PA1|CURR^^^",
            "~~~PA2|VOLT^^^",
            "~~~PA2|CURR^^^",
            "~~~PA3|VOLT^^^",
            "~~~PA3|CURR^^^",
            "~~~XR^^^",
            "~~~XBT^^^"});
            this.Command.Location = new System.Drawing.Point(140, 108);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(230, 21);
            this.Command.TabIndex = 4;
            // 
            // EMSLabel
            // 
            this.EMSLabel.AutoSize = true;
            this.EMSLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EMSLabel.ForeColor = System.Drawing.Color.Blue;
            this.EMSLabel.Location = new System.Drawing.Point(43, 36);
            this.EMSLabel.Name = "EMSLabel";
            this.EMSLabel.Size = new System.Drawing.Size(358, 18);
            this.EMSLabel.TabIndex = 5;
            this.EMSLabel.Text = "Enterprise EMS Gateway Demo Program";
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // IncomingText
            // 
            this.IncomingText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IncomingText.Location = new System.Drawing.Point(46, 149);
            this.IncomingText.Multiline = true;
            this.IncomingText.Name = "IncomingText";
            this.IncomingText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.IncomingText.Size = new System.Drawing.Size(324, 201);
            this.IncomingText.TabIndex = 6;
            // 
            // TimerMain
            // 
            this.TimerMain.Interval = 1000;
            this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
            // 
            // RoomA
            // 
            this.RoomA.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RoomA.Controls.Add(this.Update);
            this.RoomA.Controls.Add(this.EnrolledStudents);
            this.RoomA.Controls.Add(this.label4);
            this.RoomA.Controls.Add(this.button16);
            this.RoomA.Controls.Add(this.button15);
            this.RoomA.Controls.Add(this.ACU1BAmpRead);
            this.RoomA.Controls.Add(this.ACU1BVoltRead);
            this.RoomA.Controls.Add(this.button12);
            this.RoomA.Controls.Add(this.button11);
            this.RoomA.Controls.Add(this.ACU1AAmpRead);
            this.RoomA.Controls.Add(this.ACU1AVoltRead);
            this.RoomA.Controls.Add(this.button8);
            this.RoomA.Controls.Add(this.button7);
            this.RoomA.Controls.Add(this.LightAmpRead);
            this.RoomA.Controls.Add(this.LightVoltRead);
            this.RoomA.Controls.Add(this.ACU1BButton);
            this.RoomA.Controls.Add(this.ACU1AButton);
            this.RoomA.Controls.Add(this.LightButton);
            this.RoomA.Controls.Add(this.label21);
            this.RoomA.Controls.Add(this.label20);
            this.RoomA.Controls.Add(this.label19);
            this.RoomA.Controls.Add(this.label18);
            this.RoomA.Controls.Add(this.label17);
            this.RoomA.Controls.Add(this.label16);
            this.RoomA.Controls.Add(this.label15);
            this.RoomA.Controls.Add(this.label14);
            this.RoomA.Controls.Add(this.label13);
            this.RoomA.Controls.Add(this.ACU1BAmps);
            this.RoomA.Controls.Add(this.ACU1AAmps);
            this.RoomA.Controls.Add(this.LightAmps);
            this.RoomA.Controls.Add(this.ACU1BVolt);
            this.RoomA.Controls.Add(this.ACU1AVolt);
            this.RoomA.Controls.Add(this.LightVolt);
            this.RoomA.Controls.Add(this.label3);
            this.RoomA.Controls.Add(this.label2);
            this.RoomA.Controls.Add(this.label1);
            this.RoomA.ForeColor = System.Drawing.Color.Navy;
            this.RoomA.Location = new System.Drawing.Point(382, 68);
            this.RoomA.Name = "RoomA";
            this.RoomA.Size = new System.Drawing.Size(365, 319);
            this.RoomA.TabIndex = 7;
            this.RoomA.TabStop = false;
            this.RoomA.Text = "Room A";
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Update.Location = new System.Drawing.Point(214, 27);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(105, 23);
            this.Update.TabIndex = 28;
            this.Update.Text = "Activate Appliance";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // EnrolledStudents
            // 
            this.EnrolledStudents.BackColor = System.Drawing.SystemColors.Menu;
            this.EnrolledStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnrolledStudents.Location = new System.Drawing.Point(169, 32);
            this.EnrolledStudents.Name = "EnrolledStudents";
            this.EnrolledStudents.Size = new System.Drawing.Size(39, 13);
            this.EnrolledStudents.TabIndex = 27;
            this.EnrolledStudents.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "No. of Enrolled Students: ";
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button16.Enabled = false;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button16.Location = new System.Drawing.Point(232, 243);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(21, 23);
            this.button16.TabIndex = 24;
            this.button16.Text = "S";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button15.Enabled = false;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button15.Location = new System.Drawing.Point(232, 208);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(21, 23);
            this.button15.TabIndex = 24;
            this.button15.Text = "S";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // ACU1BAmpRead
            // 
            this.ACU1BAmpRead.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACU1BAmpRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ACU1BAmpRead.Location = new System.Drawing.Point(232, 173);
            this.ACU1BAmpRead.Name = "ACU1BAmpRead";
            this.ACU1BAmpRead.Size = new System.Drawing.Size(21, 23);
            this.ACU1BAmpRead.TabIndex = 24;
            this.ACU1BAmpRead.Text = "S";
            this.ACU1BAmpRead.UseVisualStyleBackColor = false;
            this.ACU1BAmpRead.Click += new System.EventHandler(this.ACU1BAmpRead_Click);
            // 
            // ACU1BVoltRead
            // 
            this.ACU1BVoltRead.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACU1BVoltRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ACU1BVoltRead.Location = new System.Drawing.Point(232, 136);
            this.ACU1BVoltRead.Name = "ACU1BVoltRead";
            this.ACU1BVoltRead.Size = new System.Drawing.Size(21, 23);
            this.ACU1BVoltRead.TabIndex = 24;
            this.ACU1BVoltRead.Text = "S";
            this.ACU1BVoltRead.UseVisualStyleBackColor = false;
            this.ACU1BVoltRead.Click += new System.EventHandler(this.ACU1BVoltRead_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button12.Enabled = false;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button12.Location = new System.Drawing.Point(128, 243);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(21, 23);
            this.button12.TabIndex = 24;
            this.button12.Text = "S";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button11.Enabled = false;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Location = new System.Drawing.Point(128, 208);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(21, 23);
            this.button11.TabIndex = 24;
            this.button11.Text = "S";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // ACU1AAmpRead
            // 
            this.ACU1AAmpRead.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACU1AAmpRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ACU1AAmpRead.Location = new System.Drawing.Point(128, 173);
            this.ACU1AAmpRead.Name = "ACU1AAmpRead";
            this.ACU1AAmpRead.Size = new System.Drawing.Size(21, 23);
            this.ACU1AAmpRead.TabIndex = 24;
            this.ACU1AAmpRead.Text = "S";
            this.ACU1AAmpRead.UseVisualStyleBackColor = false;
            this.ACU1AAmpRead.Click += new System.EventHandler(this.ACU1AAmpRead_Click);
            // 
            // ACU1AVoltRead
            // 
            this.ACU1AVoltRead.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACU1AVoltRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ACU1AVoltRead.Location = new System.Drawing.Point(128, 136);
            this.ACU1AVoltRead.Name = "ACU1AVoltRead";
            this.ACU1AVoltRead.Size = new System.Drawing.Size(21, 23);
            this.ACU1AVoltRead.TabIndex = 24;
            this.ACU1AVoltRead.Text = "S";
            this.ACU1AVoltRead.UseVisualStyleBackColor = false;
            this.ACU1AVoltRead.Click += new System.EventHandler(this.ACU1AVoltRead_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button8.Enabled = false;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Location = new System.Drawing.Point(26, 243);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(21, 23);
            this.button8.TabIndex = 24;
            this.button8.Text = "S";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.Enabled = false;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Location = new System.Drawing.Point(26, 208);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(21, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "S";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // LightAmpRead
            // 
            this.LightAmpRead.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LightAmpRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LightAmpRead.Location = new System.Drawing.Point(26, 173);
            this.LightAmpRead.Name = "LightAmpRead";
            this.LightAmpRead.Size = new System.Drawing.Size(21, 23);
            this.LightAmpRead.TabIndex = 25;
            this.LightAmpRead.Text = "S";
            this.LightAmpRead.UseVisualStyleBackColor = false;
            this.LightAmpRead.Click += new System.EventHandler(this.LightAmpRead_Click);
            // 
            // LightVoltRead
            // 
            this.LightVoltRead.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LightVoltRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LightVoltRead.Location = new System.Drawing.Point(26, 136);
            this.LightVoltRead.Name = "LightVoltRead";
            this.LightVoltRead.Size = new System.Drawing.Size(21, 23);
            this.LightVoltRead.TabIndex = 23;
            this.LightVoltRead.Text = "S";
            this.LightVoltRead.UseVisualStyleBackColor = false;
            this.LightVoltRead.Click += new System.EventHandler(this.LightVoltRead_Click);
            // 
            // ACU1BButton
            // 
            this.ACU1BButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACU1BButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ACU1BButton.Location = new System.Drawing.Point(259, 99);
            this.ACU1BButton.Name = "ACU1BButton";
            this.ACU1BButton.Size = new System.Drawing.Size(48, 23);
            this.ACU1BButton.TabIndex = 22;
            this.ACU1BButton.Text = "On/Off";
            this.ACU1BButton.UseVisualStyleBackColor = false;
            this.ACU1BButton.Click += new System.EventHandler(this.ACU1BButton_Click);
            // 
            // ACU1AButton
            // 
            this.ACU1AButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ACU1AButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ACU1AButton.Location = new System.Drawing.Point(155, 99);
            this.ACU1AButton.Name = "ACU1AButton";
            this.ACU1AButton.Size = new System.Drawing.Size(48, 23);
            this.ACU1AButton.TabIndex = 22;
            this.ACU1AButton.Text = "On/Off";
            this.ACU1AButton.UseVisualStyleBackColor = false;
            this.ACU1AButton.Click += new System.EventHandler(this.ACU1AButton_Click);
            // 
            // LightButton
            // 
            this.LightButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LightButton.Location = new System.Drawing.Point(53, 99);
            this.LightButton.Name = "LightButton";
            this.LightButton.Size = new System.Drawing.Size(48, 23);
            this.LightButton.TabIndex = 21;
            this.LightButton.Text = "On/Off";
            this.LightButton.UseVisualStyleBackColor = false;
            this.LightButton.Click += new System.EventHandler(this.LightButton_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(256, 282);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "PF";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(152, 282);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 13);
            this.label20.TabIndex = 19;
            this.label20.Text = "PF";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(53, 282);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "PF";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(256, 248);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "VARs";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(152, 248);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "VARs";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(53, 248);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "VARs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(256, 213);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Watts";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(152, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Watts";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 213);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Watts";
            // 
            // ACU1BAmps
            // 
            this.ACU1BAmps.AutoSize = true;
            this.ACU1BAmps.Location = new System.Drawing.Point(256, 178);
            this.ACU1BAmps.Name = "ACU1BAmps";
            this.ACU1BAmps.Size = new System.Drawing.Size(33, 13);
            this.ACU1BAmps.TabIndex = 11;
            this.ACU1BAmps.Text = "Amps";
            // 
            // ACU1AAmps
            // 
            this.ACU1AAmps.AutoSize = true;
            this.ACU1AAmps.Location = new System.Drawing.Point(152, 178);
            this.ACU1AAmps.Name = "ACU1AAmps";
            this.ACU1AAmps.Size = new System.Drawing.Size(33, 13);
            this.ACU1AAmps.TabIndex = 10;
            this.ACU1AAmps.Text = "Amps";
            // 
            // LightAmps
            // 
            this.LightAmps.AutoSize = true;
            this.LightAmps.Location = new System.Drawing.Point(53, 178);
            this.LightAmps.Name = "LightAmps";
            this.LightAmps.Size = new System.Drawing.Size(33, 13);
            this.LightAmps.TabIndex = 9;
            this.LightAmps.Text = "Amps";
            // 
            // ACU1BVolt
            // 
            this.ACU1BVolt.AutoSize = true;
            this.ACU1BVolt.Location = new System.Drawing.Point(256, 141);
            this.ACU1BVolt.Name = "ACU1BVolt";
            this.ACU1BVolt.Size = new System.Drawing.Size(30, 13);
            this.ACU1BVolt.TabIndex = 8;
            this.ACU1BVolt.Text = "Volts";
            // 
            // ACU1AVolt
            // 
            this.ACU1AVolt.AutoSize = true;
            this.ACU1AVolt.Location = new System.Drawing.Point(152, 141);
            this.ACU1AVolt.Name = "ACU1AVolt";
            this.ACU1AVolt.Size = new System.Drawing.Size(30, 13);
            this.ACU1AVolt.TabIndex = 7;
            this.ACU1AVolt.Text = "Volts";
            // 
            // LightVolt
            // 
            this.LightVolt.AutoSize = true;
            this.LightVolt.Location = new System.Drawing.Point(53, 141);
            this.LightVolt.Name = "LightVolt";
            this.LightVolt.Size = new System.Drawing.Size(30, 13);
            this.LightVolt.TabIndex = 6;
            this.LightVolt.Text = "Volts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(256, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ACU1B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ACU1A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Light";
            // 
            // ClearText
            // 
            this.ClearText.Location = new System.Drawing.Point(295, 364);
            this.ClearText.Name = "ClearText";
            this.ClearText.Size = new System.Drawing.Size(75, 23);
            this.ClearText.TabIndex = 8;
            this.ClearText.Text = "Clear";
            this.ClearText.UseVisualStyleBackColor = true;
            this.ClearText.Click += new System.EventHandler(this.ClearText_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(672, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Exit >>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClearText);
            this.Controls.Add(this.RoomA);
            this.Controls.Add(this.IncomingText);
            this.Controls.Add(this.EMSLabel);
            this.Controls.Add(this.Command);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.PortList);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "EMS Gateway";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.RoomA.ResumeLayout(false);
            this.RoomA.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.ComboBox PortList;
        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.ComboBox Command;
        private System.Windows.Forms.Label EMSLabel;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.TextBox IncomingText;
        private System.Windows.Forms.Timer TimerMain;
        private System.Windows.Forms.GroupBox RoomA;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ACU1BAmps;
        private System.Windows.Forms.Label ACU1AAmps;
        private System.Windows.Forms.Label LightAmps;
        private System.Windows.Forms.Label ACU1BVolt;
        private System.Windows.Forms.Label ACU1AVolt;
        private System.Windows.Forms.Label LightVolt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button ACU1BAmpRead;
        private System.Windows.Forms.Button ACU1BVoltRead;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button ACU1AAmpRead;
        private System.Windows.Forms.Button ACU1AVoltRead;
        private System.Windows.Forms.Button ACU1BButton;
        private System.Windows.Forms.Button ACU1AButton;
        private System.Windows.Forms.Button LightButton;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button LightAmpRead;
        private System.Windows.Forms.Button LightVoltRead;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.TextBox EnrolledStudents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ClearText;
        private System.Windows.Forms.Button button1;
    }
}

