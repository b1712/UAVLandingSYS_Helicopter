namespace UAVImplementation.PresentationLayer
{
    partial class UAV_UI
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
            this.txtFlightStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receive IP Address";
            // 
            // txtBoxReceiveIPAddress
            // 
            this.txtBoxReceiveIPAddress.Location = new System.Drawing.Point(128, 24);
            this.txtBoxReceiveIPAddress.Name = "txtBoxReceiveIPAddress";
            this.txtBoxReceiveIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtBoxReceiveIPAddress.TabIndex = 1;
            this.txtBoxReceiveIPAddress.Text = "192.168.1.100";
            // 
            // txtBoxReceivePortNo
            // 
            this.txtBoxReceivePortNo.Location = new System.Drawing.Point(128, 50);
            this.txtBoxReceivePortNo.Name = "txtBoxReceivePortNo";
            this.txtBoxReceivePortNo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxReceivePortNo.TabIndex = 2;
            this.txtBoxReceivePortNo.Text = "9060";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
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
            this.btnIntercept.Click += new System.EventHandler(this.btnIntercept_Click);
            // 
            // txtBoxShipCoords
            // 
            this.txtBoxShipCoords.Location = new System.Drawing.Point(273, 24);
            this.txtBoxShipCoords.Multiline = true;
            this.txtBoxShipCoords.Name = "txtBoxShipCoords";
            this.txtBoxShipCoords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxShipCoords.Size = new System.Drawing.Size(531, 361);
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
            this.btnEstComms.Click += new System.EventHandler(this.btnEstComms_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connection Status";
            // 
            // txtBoxConnectionStatus
            // 
            this.txtBoxConnectionStatus.Location = new System.Drawing.Point(128, 130);
            this.txtBoxConnectionStatus.Name = "txtBoxConnectionStatus";
            this.txtBoxConnectionStatus.Size = new System.Drawing.Size(100, 20);
            this.txtBoxConnectionStatus.TabIndex = 8;
            this.txtBoxConnectionStatus.Text = "No Connection";
            // 
            // txtBoxSendIPAddress
            // 
            this.txtBoxSendIPAddress.Location = new System.Drawing.Point(128, 77);
            this.txtBoxSendIPAddress.Name = "txtBoxSendIPAddress";
            this.txtBoxSendIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSendIPAddress.TabIndex = 9;
            this.txtBoxSendIPAddress.Text = "192.168.1.101";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Send IP Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Send Port Number";
            // 
            // txtBoxSendPortNo
            // 
            this.txtBoxSendPortNo.Location = new System.Drawing.Point(128, 104);
            this.txtBoxSendPortNo.Name = "txtBoxSendPortNo";
            this.txtBoxSendPortNo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSendPortNo.TabIndex = 12;
            this.txtBoxSendPortNo.Text = "9050";
            // 
            // txtFlightStatus
            // 
            this.txtFlightStatus.Location = new System.Drawing.Point(128, 156);
            this.txtFlightStatus.Name = "txtFlightStatus";
            this.txtFlightStatus.Size = new System.Drawing.Size(100, 20);
            this.txtFlightStatus.TabIndex = 13;
            this.txtFlightStatus.Text = "Airbourne";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 159);
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
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // UAV_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 484);
            this.Controls.Add(this.btnTemp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFlightStatus);
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
            this.Name = "UAV_UI";
            this.Text = "UAV_UI";
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
        private System.Windows.Forms.TextBox txtFlightStatus;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button btnTemp;
    }
}