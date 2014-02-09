using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UAVImplementation.ServiceLayer;
using System.Net.Sockets;

namespace UAVImplementation.PresentationLayer
{
    public partial class UAV_UI : Form
    {
        UDPReceiver udpReceiver;
        UDPSender udpSender;
        private bool isReceivingCoordinates = false;
        //private float[] shipCoordinates;
        public float[] shipCoordinates;
        
        public UAV_UI()
        {
            InitializeComponent();
        }

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                udpReceiver = new UDPReceiver(Convert.ToInt32(txtBoxShipPortNo.Text));

                udpReceiver.PropertyChanged += new PropertyChangedEventHandler(shipCoordinatesPropertyChange);

                udpReceiver.StartConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occurred with the Receive socket: " +
                    ex.Message);
            }
        }

        private void btnIntercept_Click(object sender, EventArgs e)
        {
            if (isReceivingCoordinates)
            {
                udpSender = new UDPSender("192.168.1.101", 9060);
                udpSender.startUDPSender();
            }
            else
            {
                MessageBox.Show("You must select the 'Calibrate' button first...", "Warning!");
            }
        }

        private void shipCoordinatesPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            shipCoordinates = udpReceiver.ShipCoordinates;

            isReceivingCoordinates = true;

            //upDateUI();
        }

        private void upDateUI()
        {
            //string message = (shipCoordinates[0] + ", " + shipCoordinates[1] + ", " + shipCoordinates[2] +"\n");
            //txtBoxShipCoords.SelectedText += System.Environment.NewLine + (message);
            //Console.WriteLine(message);

            //txtBoxShipCoords.Invoke(new UpdateTextCallback(this.UpdateText), 
            //new object[]{message});
        }

        public delegate void UpdateTextCallback(string message);

        private void UpdateText(string message)
        {
            txtBoxShipCoords.SelectedText += System.Environment.NewLine + (message);
        }
    }
}




