using UAVImplementation.ServiceLayer;
using UAVImplementation.BusinessLayer.CameraSimulator;
using System.ComponentModel;
using System;

namespace UAVImplementation.ControlLayer
{
    public class UavRecieveController : INotifyPropertyChanged
    {
        #region fields

        private bool _isReceiving;
        private double[] _receivedShipCoordinates;
        private readonly int _port;
        private UdpReceiver _udpReceiver;

        #endregion

        #region Class Properties

        public double[] ReceivedShipCoordinates
        {
            get { return _receivedShipCoordinates; }
            set
            {
                _receivedShipCoordinates = value;
                NotifyPropertyChanged("ReceivedShipCoordinates");
            }
        }

        public bool IsReceiving
        {
            get { return _isReceiving; }
            set
            {
                _isReceiving = value;
                NotifyPropertyChanged("IsReceiving");
            }
        }

        #endregion

        #region Handler and Notify Method

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public UavRecieveController(int port)
        {
            _port = port;
        }

        public void StartUdpReceiver()
        {
            _udpReceiver = new UdpReceiver(_port);

            ImageDataSingleton.GetInstance().SetupReceiveListner(this);

            _udpReceiver.PropertyChanged += UdpReceiverPropertyChange;
            
            _udpReceiver.StartConnection();
        }

        private void UdpReceiverPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("IsReceivingCoordinates"))
            {
                IsReceiving = _udpReceiver.IsReceivingCoordinates;
            }
            if (e.PropertyName.Equals("ShipCoordinates"))
            {
                ReceivedShipCoordinates = _udpReceiver.ShipCoordinates;
            }

            //shipCoordinates = udpReceiver.ShipCoordinates;

            //isReceivingCoordinates = true;

            //if (isIntercept)
            //{
            //    udpSender.startUDPSender(shipCoordinates);
            //}

            //upDateUI();
        }


        

        
    }
}
