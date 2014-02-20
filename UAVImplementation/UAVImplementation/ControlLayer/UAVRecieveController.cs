using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UAVImplementation.ServiceLayer;
using UAVImplementation.BusinessLayer;
using UAVImplementation.BusinessLayer.CameraSimulator;
using System.ComponentModel;

namespace UAVImplementation.ControlLayer
{
    public class UAVRecieveController : INotifyPropertyChanged
    {
        private bool isReceiving;
        private float[] receivedCoordinates;
        private int port;
        UDPReceiver udpReceiver;
        ReceiveData receiveData;

        public float[] ReceivedCoordinates
        {
            get { return receivedCoordinates; }
            set
            {
                receivedCoordinates = value;
                NotifyPropertyChanged("ReceivedCoordinates");
            }
        }

        public bool IsReceiving
        {
            get { return isReceiving; }
            set
            {
                this.isReceiving = value;
                NotifyPropertyChanged("IsReceiving");
            }
        }
        
        
        public UAVRecieveController(int port)
        {
            this.port = port;
        }

        public void startUDPReceiver()
        {
            udpReceiver = new UDPReceiver(port);
            receiveData = new ReceiveData();

            udpReceiver.PropertyChanged += new PropertyChangedEventHandler(UDPReceiverPropertyChange);
            
            udpReceiver.startConnection();
        }

        private void UDPReceiverPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("IsReceivingCoordinates"))
            {
                IsReceiving = udpReceiver.IsReceivingCoordinates;
                //receiveData.CurrentShipCoordinates = udpReceiver.ShipCoordinates;
                //receiveData.upDateCoordinates(udpReceiver.ShipCoordinates);
            }
            if(e.PropertyName.Equals("ShipCoordinates"))
            {
                receiveData.updateCoordinates(udpReceiver.ShipCoordinates);

                //**************Temp***********
                GlobalVarsTemp.TempCoord = udpReceiver.ShipCoordinates;
            }

            //shipCoordinates = udpReceiver.ShipCoordinates;

            //isReceivingCoordinates = true;

            //if (isIntercept)
            //{
            //    udpSender.startUDPSender(shipCoordinates);
            //}

            //upDateUI();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
