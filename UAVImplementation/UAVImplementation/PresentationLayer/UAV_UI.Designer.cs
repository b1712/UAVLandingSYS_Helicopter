namespace UAVImplementation.PresentationLayer
{
    partial class UavUi
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxReceiveIPAddress = new System.Windows.Forms.TextBox();
            this.txtBoxReceivePortNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIntercept = new System.Windows.Forms.Button();
            this.txtBoxShipCoords = new System.Windows.Forms.TextBox();
            this.btnEstComms = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxConnectionStatus = new System.Windows.Forms.TextBox();
            this.txtBoxSendIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxSendPortNo = new System.Windows.Forms.TextBox();
            this.txtBoxFlightStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTemp = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxFocalX = new System.Windows.Forms.TextBox();
            this.txtBoxFocalY = new System.Windows.Forms.TextBox();
            this.txtBoxFocalZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxMegapixels = new System.Windows.Forms.TextBox();
            this.txtBoxCcdHeight = new System.Windows.Forms.TextBox();
            this.txtBoxCcdWidth = new System.Windows.Forms.TextBox();
            this.txtBoxFocalLength = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBoxPrimaryTarget = new System.Windows.Forms.TextBox();
            this.txtBoxSecondaryTarget = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.PrimaryOn = new System.Windows.Forms.Button();
            this.PrimaryOff = new System.Windows.Forms.Button();
            this.SecondaryOn = new System.Windows.Forms.Button();
            this.SecondaryOff = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receive IP Address";
            // 
            // txtBoxReceiveIPAddress
            // 
            this.txtBoxReceiveIPAddress.Location = new System.Drawing.Point(151, 24);
            this.txtBoxReceiveIPAddress.Name = "txtBoxReceiveIPAddress";
            this.txtBoxReceiveIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtBoxReceiveIPAddress.TabIndex = 1;
            this.txtBoxReceiveIPAddress.Text = "192.168.1.100";
            // 
            // txtBoxReceivePortNo
            // 
            this.txtBoxReceivePortNo.Location = new System.Drawing.Point(151, 50);
            this.txtBoxReceivePortNo.Name = "txtBoxReceivePortNo";
            this.txtBoxReceivePortNo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxReceivePortNo.TabIndex = 2;
            this.txtBoxReceivePortNo.Text = "9060";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Receive Port Number";
            // 
            // btnIntercept
            // 
            this.btnIntercept.Location = new System.Drawing.Point(544, 441);
            this.btnIntercept.Name = "btnIntercept";
            this.btnIntercept.Size = new System.Drawing.Size(123, 23);
            this.btnIntercept.TabIndex = 4;
            this.btnIntercept.Text = "Commence Intercept";
            this.btnIntercept.UseVisualStyleBackColor = true;
            this.btnIntercept.Click += new System.EventHandler(this.BtnInterceptClick);
            // 
            // txtBoxShipCoords
            // 
            this.txtBoxShipCoords.Location = new System.Drawing.Point(274, 24);
            this.txtBoxShipCoords.Multiline = true;
            this.txtBoxShipCoords.Name = "txtBoxShipCoords";
            this.txtBoxShipCoords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxShipCoords.Size = new System.Drawing.Size(290, 361);
            this.txtBoxShipCoords.TabIndex = 5;
            // 
            // btnEstComms
            // 
            this.btnEstComms.Location = new System.Drawing.Point(681, 441);
            this.btnEstComms.Name = "btnEstComms";
            this.btnEstComms.Size = new System.Drawing.Size(123, 23);
            this.btnEstComms.TabIndex = 6;
            this.btnEstComms.Text = "Establish Comms";
            this.btnEstComms.UseVisualStyleBackColor = true;
            this.btnEstComms.Click += new System.EventHandler(this.BtnEstCommsClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connection Status";
            // 
            // txtBoxConnectionStatus
            // 
            this.txtBoxConnectionStatus.Location = new System.Drawing.Point(151, 130);
            this.txtBoxConnectionStatus.Name = "txtBoxConnectionStatus";
            this.txtBoxConnectionStatus.Size = new System.Drawing.Size(100, 20);
            this.txtBoxConnectionStatus.TabIndex = 8;
            this.txtBoxConnectionStatus.Text = "No Connection";
            // 
            // txtBoxSendIPAddress
            // 
            this.txtBoxSendIPAddress.Location = new System.Drawing.Point(151, 77);
            this.txtBoxSendIPAddress.Name = "txtBoxSendIPAddress";
            this.txtBoxSendIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSendIPAddress.TabIndex = 9;
            this.txtBoxSendIPAddress.Text = "192.168.1.101";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Send IP Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Send Port Number";
            // 
            // txtBoxSendPortNo
            // 
            this.txtBoxSendPortNo.Location = new System.Drawing.Point(151, 104);
            this.txtBoxSendPortNo.Name = "txtBoxSendPortNo";
            this.txtBoxSendPortNo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSendPortNo.TabIndex = 12;
            this.txtBoxSendPortNo.Text = "9050";
            // 
            // txtBoxFlightStatus
            // 
            this.txtBoxFlightStatus.Location = new System.Drawing.Point(151, 156);
            this.txtBoxFlightStatus.Name = "txtBoxFlightStatus";
            this.txtBoxFlightStatus.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFlightStatus.TabIndex = 13;
            this.txtBoxFlightStatus.Text = "Airbourne";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Flight Status";
            // 
            // btnTemp
            // 
            this.btnTemp.Location = new System.Drawing.Point(439, 441);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(75, 23);
            this.btnTemp.TabIndex = 15;
            this.btnTemp.Text = "temp";
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.BtnTempClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "UAV Camera Focal Point";
            // 
            // txtBoxFocalX
            // 
            this.txtBoxFocalX.Location = new System.Drawing.Point(33, 58);
            this.txtBoxFocalX.Name = "txtBoxFocalX";
            this.txtBoxFocalX.Size = new System.Drawing.Size(40, 20);
            this.txtBoxFocalX.TabIndex = 17;
            this.txtBoxFocalX.Text = "0";
            // 
            // txtBoxFocalY
            // 
            this.txtBoxFocalY.Location = new System.Drawing.Point(79, 58);
            this.txtBoxFocalY.Name = "txtBoxFocalY";
            this.txtBoxFocalY.Size = new System.Drawing.Size(40, 20);
            this.txtBoxFocalY.TabIndex = 18;
            this.txtBoxFocalY.Text = "100";
            // 
            // txtBoxFocalZ
            // 
            this.txtBoxFocalZ.Location = new System.Drawing.Point(125, 58);
            this.txtBoxFocalZ.Name = "txtBoxFocalZ";
            this.txtBoxFocalZ.Size = new System.Drawing.Size(40, 20);
            this.txtBoxFocalZ.TabIndex = 19;
            this.txtBoxFocalZ.Text = "-116";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Z";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Y";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBoxMegapixels);
            this.panel1.Controls.Add(this.txtBoxCcdHeight);
            this.panel1.Controls.Add(this.txtBoxCcdWidth);
            this.panel1.Controls.Add(this.txtBoxFocalLength);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtBoxFocalX);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBoxFocalY);
            this.panel1.Controls.Add(this.txtBoxFocalZ);
            this.panel1.Location = new System.Drawing.Point(604, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 358);
            this.panel1.TabIndex = 23;
            this.panel1.Tag = "";
            // 
            // txtBoxMegapixels
            // 
            this.txtBoxMegapixels.Location = new System.Drawing.Point(122, 179);
            this.txtBoxMegapixels.Name = "txtBoxMegapixels";
            this.txtBoxMegapixels.Size = new System.Drawing.Size(43, 20);
            this.txtBoxMegapixels.TabIndex = 30;
            this.txtBoxMegapixels.Text = "1";
            // 
            // txtBoxCcdHeight
            // 
            this.txtBoxCcdHeight.Location = new System.Drawing.Point(122, 153);
            this.txtBoxCcdHeight.Name = "txtBoxCcdHeight";
            this.txtBoxCcdHeight.Size = new System.Drawing.Size(43, 20);
            this.txtBoxCcdHeight.TabIndex = 29;
            this.txtBoxCcdHeight.Text = "24";
            // 
            // txtBoxCcdWidth
            // 
            this.txtBoxCcdWidth.Location = new System.Drawing.Point(122, 127);
            this.txtBoxCcdWidth.Name = "txtBoxCcdWidth";
            this.txtBoxCcdWidth.Size = new System.Drawing.Size(43, 20);
            this.txtBoxCcdWidth.TabIndex = 28;
            this.txtBoxCcdWidth.Text = "36";
            // 
            // txtBoxFocalLength
            // 
            this.txtBoxFocalLength.Location = new System.Drawing.Point(122, 101);
            this.txtBoxFocalLength.Name = "txtBoxFocalLength";
            this.txtBoxFocalLength.Size = new System.Drawing.Size(43, 20);
            this.txtBoxFocalLength.TabIndex = 27;
            this.txtBoxFocalLength.Text = "30";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(44, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "CCD Chip (H)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(54, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Megapixels";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "CCD Chip (W)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Focal Length";
            // 
            // txtBoxPrimaryTarget
            // 
            this.txtBoxPrimaryTarget.BackColor = System.Drawing.Color.Pink;
            this.txtBoxPrimaryTarget.Location = new System.Drawing.Point(151, 180);
            this.txtBoxPrimaryTarget.Name = "txtBoxPrimaryTarget";
            this.txtBoxPrimaryTarget.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPrimaryTarget.TabIndex = 24;
            this.txtBoxPrimaryTarget.Text = "No...";
            // 
            // txtBoxSecondaryTarget
            // 
            this.txtBoxSecondaryTarget.BackColor = System.Drawing.Color.Pink;
            this.txtBoxSecondaryTarget.Location = new System.Drawing.Point(151, 207);
            this.txtBoxSecondaryTarget.Name = "txtBoxSecondaryTarget";
            this.txtBoxSecondaryTarget.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSecondaryTarget.TabIndex = 25;
            this.txtBoxSecondaryTarget.Text = "No...";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Primary Target Acquired";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 209);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(137, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Secondary Target Acquired";
            // 
            // PrimaryOn
            // 
            this.PrimaryOn.Location = new System.Drawing.Point(274, 406);
            this.PrimaryOn.Name = "PrimaryOn";
            this.PrimaryOn.Size = new System.Drawing.Size(64, 23);
            this.PrimaryOn.TabIndex = 28;
            this.PrimaryOn.Text = "PrimaryOn";
            this.PrimaryOn.UseVisualStyleBackColor = true;
            this.PrimaryOn.Click += new System.EventHandler(this.PrimaryOnClick);
            // 
            // PrimaryOff
            // 
            this.PrimaryOff.Location = new System.Drawing.Point(274, 441);
            this.PrimaryOff.Name = "PrimaryOff";
            this.PrimaryOff.Size = new System.Drawing.Size(64, 23);
            this.PrimaryOff.TabIndex = 29;
            this.PrimaryOff.Text = "PrimaryOff";
            this.PrimaryOff.UseVisualStyleBackColor = true;
            this.PrimaryOff.Click += new System.EventHandler(this.PrimaryOffClick);
            // 
            // SecondaryOn
            // 
            this.SecondaryOn.Location = new System.Drawing.Point(166, 406);
            this.SecondaryOn.Name = "SecondaryOn";
            this.SecondaryOn.Size = new System.Drawing.Size(85, 23);
            this.SecondaryOn.TabIndex = 30;
            this.SecondaryOn.Text = "SecondaryOn";
            this.SecondaryOn.UseVisualStyleBackColor = true;
            this.SecondaryOn.Click += new System.EventHandler(this.SecondaryOnClick);
            // 
            // SecondaryOff
            // 
            this.SecondaryOff.Location = new System.Drawing.Point(166, 441);
            this.SecondaryOff.Name = "SecondaryOff";
            this.SecondaryOff.Size = new System.Drawing.Size(85, 23);
            this.SecondaryOff.TabIndex = 31;
            this.SecondaryOff.Text = "SecondaryOff";
            this.SecondaryOff.UseVisualStyleBackColor = true;
            this.SecondaryOff.Click += new System.EventHandler(this.SecondaryOffClick);
            // 
            // UavUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 484);
            this.Controls.Add(this.SecondaryOff);
            this.Controls.Add(this.SecondaryOn);
            this.Controls.Add(this.PrimaryOff);
            this.Controls.Add(this.PrimaryOn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBoxSecondaryTarget);
            this.Controls.Add(this.txtBoxPrimaryTarget);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTemp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxFlightStatus);
            this.Controls.Add(this.txtBoxSendPortNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBoxSendIPAddress);
            this.Controls.Add(this.txtBoxConnectionStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEstComms);
            this.Controls.Add(this.txtBoxShipCoords);
            this.Controls.Add(this.btnIntercept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxReceivePortNo);
            this.Controls.Add(this.txtBoxReceiveIPAddress);
            this.Controls.Add(this.label1);
            this.Name = "UavUi";
            this.Text = "UAV_UI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxReceiveIPAddress;
        private System.Windows.Forms.TextBox txtBoxReceivePortNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIntercept;
        private System.Windows.Forms.TextBox txtBoxShipCoords;
        private System.Windows.Forms.Button btnEstComms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxConnectionStatus;
        private System.Windows.Forms.TextBox txtBoxSendIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxSendPortNo;
        private System.Windows.Forms.TextBox txtBoxFlightStatus;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxFocalX;
        private System.Windows.Forms.TextBox txtBoxFocalY;
        private System.Windows.Forms.TextBox txtBoxFocalZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxMegapixels;
        private System.Windows.Forms.TextBox txtBoxCcdHeight;
        private System.Windows.Forms.TextBox txtBoxCcdWidth;
        private System.Windows.Forms.TextBox txtBoxFocalLength;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBoxPrimaryTarget;
        private System.Windows.Forms.TextBox txtBoxSecondaryTarget;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button PrimaryOn;
        private System.Windows.Forms.Button PrimaryOff;
        private System.Windows.Forms.Button SecondaryOn;
        private System.Windows.Forms.Button SecondaryOff;
    }
}