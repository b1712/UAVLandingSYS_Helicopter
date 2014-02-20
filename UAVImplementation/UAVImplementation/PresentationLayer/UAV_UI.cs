using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UAVImplementation.ServiceLayer;
using UAVImplementation.ControlLayer;
using UAVImplementation.BusinessLayer;
using System.Net.Sockets;

namespace UAVImplementation.PresentationLayer
{
    public partial class UAV_UI : Form
    {
        //UDPReceiver udpReceiver;
        //UDPSender udpSender;
        private bool isReceivingData = false;
        UAVRecieveController receiveController;
        UAVSendController sendController;

        public UAV_UI()
        {
            InitializeComponent();
        }

        private void btnEstComms_Click(object sender, EventArgs e)
        {
            try
            {
                receiveController = new UAVRecieveController(Convert.ToInt32(txtBoxReceivePortNo.Text));

                receiveController.PropertyChanged += new PropertyChangedEventHandler(controllerPropertyChange);

                receiveController.startUDPReceiver();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occurred with the Receive socket: " + ex.Message);
            }
        }

        private void btnIntercept_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReceivingData)
                {
                    //isIntercept = true;
                    sendController = new UAVSendController(txtBoxSendIPAddress.Text,
                                            Convert.ToInt32(txtBoxSendPortNo.Text));

                    sendController.startUDPSender();
                }
                else
                {
                    MessageBox.Show("You must select the 'Establish Comms' button first...", "Warning!");
                    btnEstComms.Focus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occurred with the Send socket: " + ex.Message);
            }
        }

        private void controllerPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("IsReceiving"))
            {
                isReceivingData = receiveController.IsReceiving;
                upDateUI();
            }
        }

        private void upDateUI()
        {
            txtBoxConnectionStatus.Invoke(new UpdateTextCallback(this.UpdateTxtBoxStatus),
            new object[] { "Connected..." });
        }

        public delegate void UpdateTextCallback(string message);

        private void UpdateTxtBoxStatus(string message)
        {
            txtBoxConnectionStatus.Text = message;
            txtBoxConnectionStatus.BackColor = Color.LightGreen;
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            FlightStatusSingleton.getInstance().IsTouchdown = true;
        }

    }
}




