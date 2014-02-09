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
            this.txtBoxShipIPAddress = new System.Windows.Forms.TextBox();
            this.txtBoxShipPortNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIntercept = new System.Windows.Forms.Button();
            this.txtBoxShipCoords = new System.Windows.Forms.TextBox();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ship IP Address";
            // 
            // txtBoxShipIPAddress
            // 
            this.txtBoxShipIPAddress.Location = new System.Drawing.Point(128, 24);
            this.txtBoxShipIPAddress.Name = "txtBoxShipIPAddress";
            this.txtBoxShipIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtBoxShipIPAddress.TabIndex = 1;
            this.txtBoxShipIPAddress.Text = "192.168.1.101";
            // 
            // txtBoxShipPortNo
            // 
            this.txtBoxShipPortNo.Location = new System.Drawing.Point(128, 66);
            this.txtBoxShipPortNo.Name = "txtBoxShipPortNo";
            this.txtBoxShipPortNo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxShipPortNo.TabIndex = 2;
            this.txtBoxShipPortNo.Text = "9050";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ship Port Number";
            // 
            // btnIntercept
            // 
            this.btnIntercept.Location = new System.Drawing.Point(585, 441);
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
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(729, 441);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(75, 23);
            this.btnCalibrate.TabIndex = 6;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // UAV_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 484);
            this.Controls.Add(this.btnCalibrate);
            this.Controls.Add(this.txtBoxShipCoords);
            this.Controls.Add(this.btnIntercept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxShipPortNo);
            this.Controls.Add(this.txtBoxShipIPAddress);
            this.Controls.Add(this.label1);
            this.Name = "UAV_UI";
            this.Text = "UAV_UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxShipIPAddress;
        private System.Windows.Forms.TextBox txtBoxShipPortNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIntercept;
        private System.Windows.Forms.TextBox txtBoxShipCoords;
        private System.Windows.Forms.Button btnCalibrate;
    }
}