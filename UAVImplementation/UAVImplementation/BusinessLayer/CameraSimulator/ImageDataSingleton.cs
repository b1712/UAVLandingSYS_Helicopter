using System.Collections.Generic;
using System.Drawing;
using UAVImplementation.ControlLayer;
using System.ComponentModel;
using UAVImplementation.BusinessLayer.INSSimulator;
using UAVImplementation.BusinessLayer.ImageProcessor;
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
        private ImageSimulation _imageSimulation;
        private ImageProcessSimulation _imageProcessSimulation;

        #endregion

        #region Class Properties

        public double[] CurrentShipCoordinates { get; set; }
        public double[] CurrentUavCoordinates { get; set; }
        public bool IsShipCoordinatesReceived { get; set; }
        public bool IsUavCoordinatesReceived { get; set; }
        public bool IsImageCoordinatesReceived { get; set; }
        public bool IsCurrentImageReceived { get; set; }
        public Bitmap CurrentImage { get; set; }
        
        // Used in lieu of image processor
        public List<Point> ListOfImageCoordinates { get; set; }

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

        public void SetupImageSimulationListener(ImageSimulation imageSimulation)
        {
            _imageSimulation = imageSimulation;
            _imageSimulation.PropertyChanged += ImageSimulationPropertyChanged;
        }

        public void SetupImageProcessorListener(ImageProcessSimulation imageProcessSimulation)
        {
            _imageProcessSimulation = imageProcessSimulation;
            _imageProcessSimulation.PropertyChanged += ImageProcessorPropertyChanged;
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

        private void ImageSimulationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CurrentImage"))
            {
                CurrentImage = _imageSimulation.CurrentImage;
                IsCurrentImageReceived = true;
            }
        }

        private void ImageProcessorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("CoordinatePointsList"))
            {
                ListOfImageCoordinates = _imageProcessSimulation.CoordinatePointsList;
                IsImageCoordinatesReceived = true;
            }
        }
    }
}
