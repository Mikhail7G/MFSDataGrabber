namespace MFSAssistant
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
            this.ConnectLabel = new System.Windows.Forms.Label();
            this.DataUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.GroundServicesMenuBtn = new System.Windows.Forms.Button();
            this.JetwayBtn = new System.Windows.Forms.Button();
            this.CateringBtn = new System.Windows.Forms.Button();
            this.LuggageBtn = new System.Windows.Forms.Button();
            this.GroundPWRBtn = new System.Windows.Forms.Button();
            this.GroundServsBtnBack = new System.Windows.Forms.Button();
            this.TUGMenuBtn = new System.Windows.Forms.Button();
            this.TUGConnBtn = new System.Windows.Forms.Button();
            this.TUGTimer = new System.Windows.Forms.Timer(this.components);
            this.TUGBackBtn = new System.Windows.Forms.Button();
            this.TugStartPBBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TUGRotation = new System.Windows.Forms.Timer(this.components);
            this.TUGPauseBtn = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConnectLabel
            // 
            this.ConnectLabel.AutoSize = true;
            this.ConnectLabel.Location = new System.Drawing.Point(116, 9);
            this.ConnectLabel.Name = "ConnectLabel";
            this.ConnectLabel.Size = new System.Drawing.Size(106, 13);
            this.ConnectLabel.TabIndex = 0;
            this.ConnectLabel.Text = "Ожидание клиента.";
            // 
            // DataUpdateTimer
            // 
            this.DataUpdateTimer.Tick += new System.EventHandler(this.DataUpdateTimer_Tick);
            // 
            // GroundServicesMenuBtn
            // 
            this.GroundServicesMenuBtn.Location = new System.Drawing.Point(12, 36);
            this.GroundServicesMenuBtn.Name = "GroundServicesMenuBtn";
            this.GroundServicesMenuBtn.Size = new System.Drawing.Size(111, 23);
            this.GroundServicesMenuBtn.TabIndex = 1;
            this.GroundServicesMenuBtn.Text = "Ground services";
            this.GroundServicesMenuBtn.UseVisualStyleBackColor = true;
            this.GroundServicesMenuBtn.Click += new System.EventHandler(this.GroundServicesMenuBtn_Click);
            // 
            // JetwayBtn
            // 
            this.JetwayBtn.Location = new System.Drawing.Point(28, 65);
            this.JetwayBtn.Name = "JetwayBtn";
            this.JetwayBtn.Size = new System.Drawing.Size(75, 23);
            this.JetwayBtn.TabIndex = 2;
            this.JetwayBtn.Text = "Jetway";
            this.JetwayBtn.UseVisualStyleBackColor = true;
            this.JetwayBtn.Visible = false;
            this.JetwayBtn.Click += new System.EventHandler(this.JetwayBtn_Click);
            // 
            // CateringBtn
            // 
            this.CateringBtn.Location = new System.Drawing.Point(28, 94);
            this.CateringBtn.Name = "CateringBtn";
            this.CateringBtn.Size = new System.Drawing.Size(75, 23);
            this.CateringBtn.TabIndex = 3;
            this.CateringBtn.Text = "Catering";
            this.CateringBtn.UseVisualStyleBackColor = true;
            this.CateringBtn.Visible = false;
            this.CateringBtn.Click += new System.EventHandler(this.CateringBtn_Click);
            // 
            // LuggageBtn
            // 
            this.LuggageBtn.Location = new System.Drawing.Point(28, 123);
            this.LuggageBtn.Name = "LuggageBtn";
            this.LuggageBtn.Size = new System.Drawing.Size(75, 23);
            this.LuggageBtn.TabIndex = 4;
            this.LuggageBtn.Text = "Luggage";
            this.LuggageBtn.UseVisualStyleBackColor = true;
            this.LuggageBtn.Visible = false;
            this.LuggageBtn.Click += new System.EventHandler(this.LuggageBtn_Click);
            // 
            // GroundPWRBtn
            // 
            this.GroundPWRBtn.Location = new System.Drawing.Point(109, 65);
            this.GroundPWRBtn.Name = "GroundPWRBtn";
            this.GroundPWRBtn.Size = new System.Drawing.Size(88, 23);
            this.GroundPWRBtn.TabIndex = 5;
            this.GroundPWRBtn.Text = "Ground PWR";
            this.GroundPWRBtn.UseVisualStyleBackColor = true;
            this.GroundPWRBtn.Visible = false;
            this.GroundPWRBtn.Click += new System.EventHandler(this.GroundPWRBtn_Click);
            // 
            // GroundServsBtnBack
            // 
            this.GroundServsBtnBack.Location = new System.Drawing.Point(28, 7);
            this.GroundServsBtnBack.Name = "GroundServsBtnBack";
            this.GroundServsBtnBack.Size = new System.Drawing.Size(75, 23);
            this.GroundServsBtnBack.TabIndex = 6;
            this.GroundServsBtnBack.Text = "Back";
            this.GroundServsBtnBack.UseVisualStyleBackColor = true;
            this.GroundServsBtnBack.Visible = false;
            this.GroundServsBtnBack.Click += new System.EventHandler(this.GroundServsBtnBack_Click);
            // 
            // TUGMenuBtn
            // 
            this.TUGMenuBtn.Location = new System.Drawing.Point(129, 36);
            this.TUGMenuBtn.Name = "TUGMenuBtn";
            this.TUGMenuBtn.Size = new System.Drawing.Size(103, 23);
            this.TUGMenuBtn.TabIndex = 7;
            this.TUGMenuBtn.Text = "TUG ops";
            this.TUGMenuBtn.UseVisualStyleBackColor = true;
            this.TUGMenuBtn.Click += new System.EventHandler(this.TUGMenuBtn_Click);
            // 
            // TUGConnBtn
            // 
            this.TUGConnBtn.Location = new System.Drawing.Point(144, 65);
            this.TUGConnBtn.Name = "TUGConnBtn";
            this.TUGConnBtn.Size = new System.Drawing.Size(75, 23);
            this.TUGConnBtn.TabIndex = 8;
            this.TUGConnBtn.Text = "TUG conn";
            this.TUGConnBtn.UseVisualStyleBackColor = true;
            this.TUGConnBtn.Visible = false;
            this.TUGConnBtn.Click += new System.EventHandler(this.TUGConnBtn_Click);
            // 
            // TUGTimer
            // 
            this.TUGTimer.Tick += new System.EventHandler(this.TUGTimer_Tick);
            // 
            // TUGBackBtn
            // 
            this.TUGBackBtn.Location = new System.Drawing.Point(144, 4);
            this.TUGBackBtn.Name = "TUGBackBtn";
            this.TUGBackBtn.Size = new System.Drawing.Size(75, 23);
            this.TUGBackBtn.TabIndex = 9;
            this.TUGBackBtn.Text = "Back";
            this.TUGBackBtn.UseVisualStyleBackColor = true;
            this.TUGBackBtn.Visible = false;
            this.TUGBackBtn.Click += new System.EventHandler(this.TUGBackBtn_Click);
            // 
            // TugStartPBBtn
            // 
            this.TugStartPBBtn.Location = new System.Drawing.Point(144, 94);
            this.TugStartPBBtn.Name = "TugStartPBBtn";
            this.TugStartPBBtn.Size = new System.Drawing.Size(75, 23);
            this.TugStartPBBtn.TabIndex = 10;
            this.TugStartPBBtn.Text = "TUG Start";
            this.TugStartPBBtn.UseVisualStyleBackColor = true;
            this.TugStartPBBtn.Visible = false;
            this.TugStartPBBtn.Click += new System.EventHandler(this.TugStartPBBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // TUGRotation
            // 
            this.TUGRotation.Tick += new System.EventHandler(this.TUGRotation_Tick);
            // 
            // TUGPauseBtn
            // 
            this.TUGPauseBtn.Location = new System.Drawing.Point(144, 123);
            this.TUGPauseBtn.Name = "TUGPauseBtn";
            this.TUGPauseBtn.Size = new System.Drawing.Size(75, 23);
            this.TUGPauseBtn.TabIndex = 12;
            this.TUGPauseBtn.Text = "TUG Pause";
            this.TUGPauseBtn.UseVisualStyleBackColor = true;
            this.TUGPauseBtn.Visible = false;
            this.TUGPauseBtn.Click += new System.EventHandler(this.TUGPauseBtn_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InfoLabel.Location = new System.Drawing.Point(-1, 26);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(130, 104);
            this.InfoLabel.TabIndex = 13;
            this.InfoLabel.Text = "Tow operated when park\r\n brakes off.Disable brakes\r\n without tow to push\r\nback. P" +
    "ress TUG conn\r\n to connect TUG\r\nUse rudder and\r\nelevator to TOW\r\n\r\n";
            this.InfoLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 170);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.TUGPauseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TugStartPBBtn);
            this.Controls.Add(this.TUGBackBtn);
            this.Controls.Add(this.TUGConnBtn);
            this.Controls.Add(this.TUGMenuBtn);
            this.Controls.Add(this.GroundServsBtnBack);
            this.Controls.Add(this.GroundPWRBtn);
            this.Controls.Add(this.LuggageBtn);
            this.Controls.Add(this.CateringBtn);
            this.Controls.Add(this.JetwayBtn);
            this.Controls.Add(this.GroundServicesMenuBtn);
            this.Controls.Add(this.ConnectLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ConnectLabel;
        private System.Windows.Forms.Timer DataUpdateTimer;
        private System.Windows.Forms.Button GroundServicesMenuBtn;
        private System.Windows.Forms.Button JetwayBtn;
        private System.Windows.Forms.Button CateringBtn;
        private System.Windows.Forms.Button LuggageBtn;
        private System.Windows.Forms.Button GroundPWRBtn;
        private System.Windows.Forms.Button GroundServsBtnBack;
        private System.Windows.Forms.Button TUGMenuBtn;
        private System.Windows.Forms.Button TUGConnBtn;
        private System.Windows.Forms.Timer TUGTimer;
        private System.Windows.Forms.Button TUGBackBtn;
        private System.Windows.Forms.Button TugStartPBBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer TUGRotation;
        private System.Windows.Forms.Button TUGPauseBtn;
        private System.Windows.Forms.Label InfoLabel;
    }
}

