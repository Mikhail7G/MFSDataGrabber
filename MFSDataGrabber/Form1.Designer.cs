
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.JetWayBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnBtn
            // 
            this.ConnBtn.Location = new System.Drawing.Point(262, 222);
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
            this.SimConnectLbl.Location = new System.Drawing.Point(290, 206);
            this.SimConnectLbl.Name = "SimConnectLbl";
            this.SimConnectLbl.Size = new System.Drawing.Size(78, 13);
            this.SimConnectLbl.TabIndex = 1;
            this.SimConnectLbl.Text = "Not connected";
            this.SimConnectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrueHeading
            // 
            this.TrueHeading.AutoSize = true;
            this.TrueHeading.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrueHeading.Location = new System.Drawing.Point(476, 44);
            this.TrueHeading.Name = "TrueHeading";
            this.TrueHeading.Size = new System.Drawing.Size(52, 16);
            this.TrueHeading.TabIndex = 2;
            this.TrueHeading.Text = "label1";
            // 
            // DataUpdateTimer
            // 
            this.DataUpdateTimer.Interval = 1500;
            this.DataUpdateTimer.Tick += new System.EventHandler(this.DataUpdateTimer_Tick);
            // 
            // Altitude
            // 
            this.Altitude.AutoSize = true;
            this.Altitude.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Altitude.Location = new System.Drawing.Point(476, 72);
            this.Altitude.Name = "Altitude";
            this.Altitude.Size = new System.Drawing.Size(52, 16);
            this.Altitude.TabIndex = 3;
            this.Altitude.Text = "label1";
            // 
            // WindPower
            // 
            this.WindPower.AutoSize = true;
            this.WindPower.Location = new System.Drawing.Point(122, 44);
            this.WindPower.Name = "WindPower";
            this.WindPower.Size = new System.Drawing.Size(35, 13);
            this.WindPower.TabIndex = 4;
            this.WindPower.Text = "label1";
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Speed.Location = new System.Drawing.Point(476, 105);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(52, 16);
            this.Speed.TabIndex = 5;
            this.Speed.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Heading";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Plane";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Altitude";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(413, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "IAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Unispace", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 9);
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
            this.label6.Location = new System.Drawing.Point(39, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Wind Speed";
            // 
            // JetWayBtn
            // 
            this.JetWayBtn.Location = new System.Drawing.Point(12, 222);
            this.JetWayBtn.Name = "JetWayBtn";
            this.JetWayBtn.Size = new System.Drawing.Size(75, 23);
            this.JetWayBtn.TabIndex = 12;
            this.JetWayBtn.Text = "Jetway";
            this.JetWayBtn.UseVisualStyleBackColor = true;
            this.JetWayBtn.Click += new System.EventHandler(this.JetWayBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(638, 295);
            this.Controls.Add(this.JetWayBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button JetWayBtn;
    }
}

