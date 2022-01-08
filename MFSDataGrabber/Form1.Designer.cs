
namespace MFSDataGrabber
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ConnBtn = new System.Windows.Forms.Button();
            this.SimConnectLbl = new System.Windows.Forms.Label();
            this.TrueHeading = new System.Windows.Forms.Label();
            this.DataUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.Altitude = new System.Windows.Forms.Label();
            this.WindPower = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.JetWayBtn = new System.Windows.Forms.Button();
            this.DoorBtn = new System.Windows.Forms.Button();
            this.GroundPowerBtn = new System.Windows.Forms.Button();
            this.CateringBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SimRateLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FromLbl = new System.Windows.Forms.Label();
            this.Tolbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Etalbl = new System.Windows.Forms.Label();
            this.Etelbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PushBackStartBtn = new System.Windows.Forms.Button();
            this.TugTestSpeedBtn = new System.Windows.Forms.Button();
            this.TugBtnBack = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.TUGspeed = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TUGAwaitTimer = new System.Windows.Forms.Timer(this.components);
            this.RudderTxt = new System.Windows.Forms.Label();
            this.TugRtationTimer = new System.Windows.Forms.Timer(this.components);
            this.HDGText = new System.Windows.Forms.Label();
            this.CargoBtnDoor = new System.Windows.Forms.Button();
            this.EmerDoorBtn = new System.Windows.Forms.Button();
            this.ParkingBrakes = new System.Windows.Forms.CheckBox();
            this.brakeStatelbl = new System.Windows.Forms.Label();
            this.VelZlbl = new System.Windows.Forms.Label();
            this.TUGStatusLbl = new System.Windows.Forms.Label();
            this.ElevatorLbl = new System.Windows.Forms.Label();
            this.ASOBOparkBrk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ConnBtn
            // 
            this.ConnBtn.Location = new System.Drawing.Point(457, 314);
            this.ConnBtn.Name = "ConnBtn";
            this.ConnBtn.Size = new System.Drawing.Size(131, 38);
            this.ConnBtn.TabIndex = 0;
            this.ConnBtn.Text = "Connect";
            this.ConnBtn.UseVisualStyleBackColor = true;
            this.ConnBtn.Click += new System.EventHandler(this.ConnBtn_Click);
            // 
            // SimConnectLbl
            // 
            this.SimConnectLbl.AutoSize = true;
            this.SimConnectLbl.Location = new System.Drawing.Point(485, 298);
            this.SimConnectLbl.Name = "SimConnectLbl";
            this.SimConnectLbl.Size = new System.Drawing.Size(78, 13);
            this.SimConnectLbl.TabIndex = 1;
            this.SimConnectLbl.Text = "Not connected";
            this.SimConnectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrueHeading
            // 
            this.TrueHeading.AutoSize = true;
            this.TrueHeading.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.TrueHeading.ForeColor = System.Drawing.Color.Coral;
            this.TrueHeading.Location = new System.Drawing.Point(252, 25);
            this.TrueHeading.Name = "TrueHeading";
            this.TrueHeading.Size = new System.Drawing.Size(35, 18);
            this.TrueHeading.TabIndex = 2;
            this.TrueHeading.Text = "999";
            // 
            // DataUpdateTimer
            // 
            this.DataUpdateTimer.Interval = 1500;
            this.DataUpdateTimer.Tick += new System.EventHandler(this.DataUpdateTimer_Tick);
            // 
            // Altitude
            // 
            this.Altitude.AutoSize = true;
            this.Altitude.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.Altitude.ForeColor = System.Drawing.Color.Coral;
            this.Altitude.Location = new System.Drawing.Point(336, 26);
            this.Altitude.Name = "Altitude";
            this.Altitude.Size = new System.Drawing.Size(62, 18);
            this.Altitude.TabIndex = 3;
            this.Altitude.Text = "999999";
            // 
            // WindPower
            // 
            this.WindPower.AutoSize = true;
            this.WindPower.Location = new System.Drawing.Point(131, 221);
            this.WindPower.Name = "WindPower";
            this.WindPower.Size = new System.Drawing.Size(35, 13);
            this.WindPower.TabIndex = 4;
            this.WindPower.Text = "label1";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.Speed.ForeColor = System.Drawing.Color.Coral;
            this.Speed.Location = new System.Drawing.Point(454, 25);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(35, 18);
            this.Speed.TabIndex = 5;
            this.Speed.Text = "999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "HDG:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(293, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "ALT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(404, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "IAS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "World";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Wind Speed";
            // 
            // JetWayBtn
            // 
            this.JetWayBtn.Location = new System.Drawing.Point(203, 314);
            this.JetWayBtn.Name = "JetWayBtn";
            this.JetWayBtn.Size = new System.Drawing.Size(75, 23);
            this.JetWayBtn.TabIndex = 12;
            this.JetWayBtn.Text = "Jetway";
            this.JetWayBtn.UseVisualStyleBackColor = true;
            this.JetWayBtn.Click += new System.EventHandler(this.JetWayBtn_Click);
            // 
            // DoorBtn
            // 
            this.DoorBtn.Location = new System.Drawing.Point(283, 259);
            this.DoorBtn.Name = "DoorBtn";
            this.DoorBtn.Size = new System.Drawing.Size(75, 23);
            this.DoorBtn.TabIndex = 13;
            this.DoorBtn.Text = "MainDoor";
            this.DoorBtn.UseVisualStyleBackColor = true;
            this.DoorBtn.Click += new System.EventHandler(this.DoorBtn_Click);
            // 
            // GroundPowerBtn
            // 
            this.GroundPowerBtn.Location = new System.Drawing.Point(283, 321);
            this.GroundPowerBtn.Name = "GroundPowerBtn";
            this.GroundPowerBtn.Size = new System.Drawing.Size(75, 38);
            this.GroundPowerBtn.TabIndex = 14;
            this.GroundPowerBtn.Text = "Ground Power";
            this.GroundPowerBtn.UseVisualStyleBackColor = true;
            this.GroundPowerBtn.Click += new System.EventHandler(this.GroundPowerBtn_Click);
            // 
            // CateringBtn
            // 
            this.CateringBtn.Location = new System.Drawing.Point(364, 314);
            this.CateringBtn.Name = "CateringBtn";
            this.CateringBtn.Size = new System.Drawing.Size(75, 23);
            this.CateringBtn.TabIndex = 15;
            this.CateringBtn.Text = "Catering";
            this.CateringBtn.UseVisualStyleBackColor = true;
            this.CateringBtn.Click += new System.EventHandler(this.CateringBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(683, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sim Rate";
            // 
            // SimRateLbl
            // 
            this.SimRateLbl.AutoSize = true;
            this.SimRateLbl.Location = new System.Drawing.Point(683, 357);
            this.SimRateLbl.Name = "SimRateLbl";
            this.SimRateLbl.Size = new System.Drawing.Size(35, 13);
            this.SimRateLbl.TabIndex = 17;
            this.SimRateLbl.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Маршрут";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Из:";
            // 
            // FromLbl
            // 
            this.FromLbl.AutoSize = true;
            this.FromLbl.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.FromLbl.ForeColor = System.Drawing.Color.Coral;
            this.FromLbl.Location = new System.Drawing.Point(42, 26);
            this.FromLbl.Name = "FromLbl";
            this.FromLbl.Size = new System.Drawing.Size(44, 18);
            this.FromLbl.TabIndex = 20;
            this.FromLbl.Text = "ZZZZ";
            // 
            // Tolbl
            // 
            this.Tolbl.AutoSize = true;
            this.Tolbl.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.Tolbl.ForeColor = System.Drawing.Color.Coral;
            this.Tolbl.Location = new System.Drawing.Point(125, 25);
            this.Tolbl.Name = "Tolbl";
            this.Tolbl.Size = new System.Drawing.Size(44, 18);
            this.Tolbl.TabIndex = 22;
            this.Tolbl.Text = "ZZZZ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(103, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "В:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 308);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label11.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Из:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label12.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(38, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 18);
            this.label12.TabIndex = 26;
            this.label12.Text = "В:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 334);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Etalbl
            // 
            this.Etalbl.AutoSize = true;
            this.Etalbl.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.Etalbl.ForeColor = System.Drawing.Color.Coral;
            this.Etalbl.Location = new System.Drawing.Point(599, 29);
            this.Etalbl.Name = "Etalbl";
            this.Etalbl.Size = new System.Drawing.Size(62, 18);
            this.Etalbl.TabIndex = 27;
            this.Etalbl.Text = "label1";
            // 
            // Etelbl
            // 
            this.Etelbl.AutoSize = true;
            this.Etelbl.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold);
            this.Etelbl.ForeColor = System.Drawing.Color.Coral;
            this.Etelbl.Location = new System.Drawing.Point(767, 29);
            this.Etelbl.Name = "Etelbl";
            this.Etelbl.Size = new System.Drawing.Size(62, 18);
            this.Etelbl.TabIndex = 28;
            this.Etelbl.Text = "label1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(511, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "Время посадки(местное)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label13.Font = new System.Drawing.Font("Unispace", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(733, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 18);
            this.label13.TabIndex = 30;
            this.label13.Text = "До посадки(ETE)";
            // 
            // PushBackStartBtn
            // 
            this.PushBackStartBtn.Location = new System.Drawing.Point(926, 282);
            this.PushBackStartBtn.Name = "PushBackStartBtn";
            this.PushBackStartBtn.Size = new System.Drawing.Size(75, 23);
            this.PushBackStartBtn.TabIndex = 31;
            this.PushBackStartBtn.Text = "TUG Conn";
            this.PushBackStartBtn.UseVisualStyleBackColor = true;
            this.PushBackStartBtn.Click += new System.EventHandler(this.PushBackStartBtn_Click);
            // 
            // TugTestSpeedBtn
            // 
            this.TugTestSpeedBtn.Location = new System.Drawing.Point(845, 316);
            this.TugTestSpeedBtn.Name = "TugTestSpeedBtn";
            this.TugTestSpeedBtn.Size = new System.Drawing.Size(75, 23);
            this.TugTestSpeedBtn.TabIndex = 32;
            this.TugTestSpeedBtn.Text = "TUG Pause";
            this.TugTestSpeedBtn.UseVisualStyleBackColor = true;
            this.TugTestSpeedBtn.Click += new System.EventHandler(this.TugTestSpeedBtn_Click);
            // 
            // TugBtnBack
            // 
            this.TugBtnBack.Location = new System.Drawing.Point(845, 283);
            this.TugBtnBack.Name = "TugBtnBack";
            this.TugBtnBack.Size = new System.Drawing.Size(75, 23);
            this.TugBtnBack.TabIndex = 36;
            this.TugBtnBack.Text = "TUG Start";
            this.TugBtnBack.UseVisualStyleBackColor = true;
            this.TugBtnBack.Click += new System.EventHandler(this.TugBtnBack_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label15.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(842, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 14);
            this.label15.TabIndex = 39;
            this.label15.Text = "TUG speed";
            // 
            // TUGspeed
            // 
            this.TUGspeed.Location = new System.Drawing.Point(856, 257);
            this.TUGspeed.Name = "TUGspeed";
            this.TUGspeed.Size = new System.Drawing.Size(43, 20);
            this.TUGspeed.TabIndex = 40;
            this.TUGspeed.Text = "0";
            this.TUGspeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TUGspeed.TextChanged += new System.EventHandler(this.TUGspeed_TextChanged);
            this.TUGspeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TUGspeed_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(692, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Baggage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(926, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "TUG disab";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TUGAwaitTimer
            // 
            this.TUGAwaitTimer.Tick += new System.EventHandler(this.TUGAwaitTimer_Tick);
            // 
            // RudderTxt
            // 
            this.RudderTxt.AutoSize = true;
            this.RudderTxt.Location = new System.Drawing.Point(853, 216);
            this.RudderTxt.Name = "RudderTxt";
            this.RudderTxt.Size = new System.Drawing.Size(42, 13);
            this.RudderTxt.TabIndex = 44;
            this.RudderTxt.Text = "Rudder";
            this.RudderTxt.Click += new System.EventHandler(this.RudderTxt_Click);
            // 
            // TugRtationTimer
            // 
            this.TugRtationTimer.Tick += new System.EventHandler(this.TugRtationTimer_Tick);
            // 
            // HDGText
            // 
            this.HDGText.AutoSize = true;
            this.HDGText.Location = new System.Drawing.Point(853, 192);
            this.HDGText.Name = "HDGText";
            this.HDGText.Size = new System.Drawing.Size(31, 13);
            this.HDGText.TabIndex = 45;
            this.HDGText.Text = "HDG";
            this.HDGText.Click += new System.EventHandler(this.HDGText_Click);
            // 
            // CargoBtnDoor
            // 
            this.CargoBtnDoor.Location = new System.Drawing.Point(202, 259);
            this.CargoBtnDoor.Name = "CargoBtnDoor";
            this.CargoBtnDoor.Size = new System.Drawing.Size(75, 23);
            this.CargoBtnDoor.TabIndex = 46;
            this.CargoBtnDoor.Text = "CargoDoor";
            this.CargoBtnDoor.UseVisualStyleBackColor = true;
            this.CargoBtnDoor.Click += new System.EventHandler(this.CargoBtnDoor_Click);
            // 
            // EmerDoorBtn
            // 
            this.EmerDoorBtn.Location = new System.Drawing.Point(364, 259);
            this.EmerDoorBtn.Name = "EmerDoorBtn";
            this.EmerDoorBtn.Size = new System.Drawing.Size(75, 23);
            this.EmerDoorBtn.TabIndex = 47;
            this.EmerDoorBtn.Text = "EmerDoor";
            this.EmerDoorBtn.UseVisualStyleBackColor = true;
            this.EmerDoorBtn.Click += new System.EventHandler(this.EmerDoorBtn_Click);
            // 
            // ParkingBrakes
            // 
            this.ParkingBrakes.AutoSize = true;
            this.ParkingBrakes.Location = new System.Drawing.Point(756, 258);
            this.ParkingBrakes.Name = "ParkingBrakes";
            this.ParkingBrakes.Size = new System.Drawing.Size(64, 17);
            this.ParkingBrakes.TabIndex = 48;
            this.ParkingBrakes.Text = "ParkBrk";
            this.ParkingBrakes.UseVisualStyleBackColor = true;
            // 
            // brakeStatelbl
            // 
            this.brakeStatelbl.AutoSize = true;
            this.brakeStatelbl.Location = new System.Drawing.Point(756, 229);
            this.brakeStatelbl.Name = "brakeStatelbl";
            this.brakeStatelbl.Size = new System.Drawing.Size(41, 13);
            this.brakeStatelbl.TabIndex = 49;
            this.brakeStatelbl.Text = "label17";
            // 
            // VelZlbl
            // 
            this.VelZlbl.AutoSize = true;
            this.VelZlbl.Location = new System.Drawing.Point(756, 192);
            this.VelZlbl.Name = "VelZlbl";
            this.VelZlbl.Size = new System.Drawing.Size(41, 13);
            this.VelZlbl.TabIndex = 50;
            this.VelZlbl.Text = "label17";
            // 
            // TUGStatusLbl
            // 
            this.TUGStatusLbl.AutoSize = true;
            this.TUGStatusLbl.Location = new System.Drawing.Point(853, 168);
            this.TUGStatusLbl.Name = "TUGStatusLbl";
            this.TUGStatusLbl.Size = new System.Drawing.Size(30, 13);
            this.TUGStatusLbl.TabIndex = 51;
            this.TUGStatusLbl.Text = "TUG";
            // 
            // ElevatorLbl
            // 
            this.ElevatorLbl.AutoSize = true;
            this.ElevatorLbl.Location = new System.Drawing.Point(901, 216);
            this.ElevatorLbl.Name = "ElevatorLbl";
            this.ElevatorLbl.Size = new System.Drawing.Size(46, 13);
            this.ElevatorLbl.TabIndex = 53;
            this.ElevatorLbl.Text = "Elevator";
            // 
            // ASOBOparkBrk
            // 
            this.ASOBOparkBrk.AutoSize = true;
            this.ASOBOparkBrk.Location = new System.Drawing.Point(756, 282);
            this.ASOBOparkBrk.Name = "ASOBOparkBrk";
            this.ASOBOparkBrk.Size = new System.Drawing.Size(64, 17);
            this.ASOBOparkBrk.TabIndex = 54;
            this.ASOBOparkBrk.Text = "ParkBrk";
            this.ASOBOparkBrk.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1054, 380);
            this.Controls.Add(this.ASOBOparkBrk);
            this.Controls.Add(this.ElevatorLbl);
            this.Controls.Add(this.TUGStatusLbl);
            this.Controls.Add(this.VelZlbl);
            this.Controls.Add(this.brakeStatelbl);
            this.Controls.Add(this.ParkingBrakes);
            this.Controls.Add(this.EmerDoorBtn);
            this.Controls.Add(this.CargoBtnDoor);
            this.Controls.Add(this.HDGText);
            this.Controls.Add(this.RudderTxt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.TUGspeed);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.TugBtnBack);
            this.Controls.Add(this.TugTestSpeedBtn);
            this.Controls.Add(this.PushBackStartBtn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Etelbl);
            this.Controls.Add(this.Etalbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Tolbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.FromLbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SimRateLbl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CateringBtn);
            this.Controls.Add(this.GroundPowerBtn);
            this.Controls.Add(this.DoorBtn);
            this.Controls.Add(this.JetWayBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.WindPower);
            this.Controls.Add(this.Altitude);
            this.Controls.Add(this.TrueHeading);
            this.Controls.Add(this.SimConnectLbl);
            this.Controls.Add(this.ConnBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnBtn;
        private System.Windows.Forms.Label SimConnectLbl;
        private System.Windows.Forms.Label TrueHeading;
        private System.Windows.Forms.Timer DataUpdateTimer;
        private System.Windows.Forms.Label Altitude;
        private System.Windows.Forms.Label WindPower;
        private System.Windows.Forms.Label Speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button JetWayBtn;
        private System.Windows.Forms.Button DoorBtn;
        private System.Windows.Forms.Button GroundPowerBtn;
        private System.Windows.Forms.Button CateringBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label SimRateLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label FromLbl;
        private System.Windows.Forms.Label Tolbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label Etalbl;
        private System.Windows.Forms.Label Etelbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button PushBackStartBtn;
        private System.Windows.Forms.Button TugTestSpeedBtn;
        private System.Windows.Forms.Button TugBtnBack;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TUGspeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer TUGAwaitTimer;
        private System.Windows.Forms.Label RudderTxt;
        private System.Windows.Forms.Timer TugRtationTimer;
        private System.Windows.Forms.Label HDGText;
        private System.Windows.Forms.Button CargoBtnDoor;
        private System.Windows.Forms.Button EmerDoorBtn;
        private System.Windows.Forms.CheckBox ParkingBrakes;
        private System.Windows.Forms.Label brakeStatelbl;
        private System.Windows.Forms.Label VelZlbl;
        private System.Windows.Forms.Label TUGStatusLbl;
        private System.Windows.Forms.Label ElevatorLbl;
        private System.Windows.Forms.CheckBox ASOBOparkBrk;
    }
}

