using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using UAVImplementation.ControlLayer;
using UAVImplementation.BusinessLayer;

namespace UAVImplementation.PresentationLayer
{
    public partial class UavUi : Form
    {
        #region fields

        private bool _isReceivingData;
        private UavRecieveController _receiveController;
        //UAVSendController sendController;
        private UavController _uavController;
        private FlightStatusSingleton _flightStatus;
        private readonly double[] _uavStartPoint = new double[3];
        private double[] _cameraSetup = new double[4]; 
        //private double _focalLength;
        //private double _ccdWidth;
        //private double _ccdHeight;
        //private double _megaPixels;

        #endregion

        public UavUi()
        {
            InitializeComponent();
        }

        private void BtnEstCommsClick(object sender, EventArgs e)
        {
            try
            {
                _receiveController = new UavRecieveController(Convert.ToInt32(txtBoxReceivePortNo.Text));

                _receiveController.PropertyChanged += ControllerPropertyChange;

                _receiveController.StartUdpReceiver();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
            }
        }

        private void BtnInterceptClick(object sender, EventArgs e)
        {
            try
            {
                _uavStartPoint[0] = double.Parse(txtBoxFocalX.Text);
                _uavStartPoint[1] = double.Parse(txtBoxFocalY.Text);
                _uavStartPoint[2] = double.Parse(txtBoxFocalZ.Text);
                _cameraSetup[0] = double.Parse(txtBoxFocalLength.Text);
                _cameraSetup[1] = double.Parse(txtBoxCcdWidth.Text);
                _cameraSetup[2] = double.Parse(txtBoxCcdHeight.Text);
                _cameraSetup[3] = double.Parse(txtBoxMegapixels.Text);
                
                if (_isReceivingData)
                {
                    _uavController = new UavController(_uavStartPoint);
                    _uavController.StartIntercept(_cameraSetup);

                    _flightStatus = FlightStatusSingleton.GetInstance();
                    _flightStatus.PropertyChanged += FlightStatusPropertyChange;

                    //sendController = new UAVSendController(txtBoxSendIPAddress.Text,
                    //                        Convert.ToInt32(txtBoxSendPortNo.Text));

                    //sendController.startUDPSender();
                }
                else
                {
                    MessageBox.Show("You must select the 'Establish Comms' button first...", "Warning!");
                    btnEstComms.Focus();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
            }
        }

        private void ControllerPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("IsReceiving"))
            {
                _isReceivingData = _receiveController.IsReceiving;
                UpdateUiConnection();
            }
        }

        private void FlightStatusPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("IsTouchdown"))
            {
                if(FlightStatusSingleton.GetInstance().IsTouchdown)
                {
                    UpdateUiFlightStatusLanded();
                }
            }
        }

        public delegate void UpdateTextCallback(string message);
        
        private void UpdateUiConnection()
        {
            txtBoxConnectionStatus.Invoke(new UpdateTextCallback(UpdateConnectionTxtBox),
                    new object[] { "Connected..." });
        }

        private void UpdateConnectionTxtBox(string message)
        {
            txtBoxConnectionStatus.Text = message;
            txtBoxConnectionStatus.BackColor = Color.LightGreen;
        }

        private void UpdateUiFlightStatusLanded()
        {
            txtBoxFlightStatus.Invoke(new UpdateTextCallback(UpdateFlightStatusTxtBox),
                    new object[] { "Landed..." });
        }

        private void UpdateFlightStatusTxtBox(string message)
        {
            txtBoxFlightStatus.Text = message;
            txtBoxFlightStatus.BackColor = Color.LightGreen;
        }

        //********************TEMP********************
        private void BtnTempClick(object sender, EventArgs e)
        {
            FlightStatusSingleton.GetInstance().IsTouchdown = true;
        }

    }
}




