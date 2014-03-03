using UAVImplementation.ControlLayer;
using System.ComponentModel;
using UAVImplementation.BusinessLayer.INSSimulator;
using System;
using System.Threading;

namespace UAVImplementation.BusinessLayer.CameraSimulator
{
    public class ImageDataSingleton
    {
        #region fields

        private volatile static ImageDataSingleton _uniqueInstance = new ImageDataSingleton();
        private static readonly object InstanceLocker = new object();

        private UavRecieveController _receiverController;
        private InsSimulation _insSimulation;

        #endregion

        #region Class Properties

        public double[] CurrentShipCoordinates { get; set; }
        public double[] CurrentUavCoordinates { get; set; }
        public bool IsShipCoordinatesReceived { get; set; }
        public bool IsUavCoordinatesReceived { get; set; }

        #endregion

        private ImageDataSingleton()
        {
        }

        public static ImageDataSingleton GetInstance()
        {
            if (_uniqueInstance == null)
            {
                lock (InstanceLocker)
                {
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new ImageDataSingleton();
                    }
                }
            }

            return _uniqueInstance;
        }

        public void SetupReceiveListner(UavRecieveController receiverController)
        {
            _receiverController = receiverController;
            _receiverController.PropertyChanged += ShipCoordinatesPropertyChanged;
        }

        public void SetupInsListener(InsSimulation insSimulation)
        {
            _insSimulation = insSimulation;
            _insSimulation.PropertyChanged += UavCoordinatesPropertyChanged;
        }
        
        private void ShipCoordinatesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ReceivedShipCoordinates"))
            {
                CurrentShipCoordinates = _receiverController.ReceivedShipCoordinates;
                IsShipCoordinatesReceived = true;
            }
        }

        private void UavCoordinatesPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentUavCoordinates"))
            {
                CurrentUavCoordinates = _insSimulation.CurrentUavCoordinates;
                IsUavCoordinatesReceived = true;
            }
        }
    }
}
