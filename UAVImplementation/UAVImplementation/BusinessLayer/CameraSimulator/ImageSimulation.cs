using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Drawing.Imaging;

namespace UAVImplementation.BusinessLayer.CameraSimulator
{
    public class ImageSimulation
    {
        #region fields

        private double[] _currentShipCoordinates = new double[18];
        private double[] _currentUavFocalPointCoordinates = new double[3];
        private readonly List<Point> _listOfPositiveImagePixels = new List<Point>();
        private readonly double _focalLengthMm;
        private readonly double _ccdWidthMm;
        private readonly double _ccdHeightMm;
        private readonly double _megaPixel;
        private int _widthInPixels;
        private int _heightInPixels;
        private int _halfWidthInPixels;
        private int _halfHeightInPixels;
        private static readonly object InstanceLocker = new object();
        private const int NumberOfShipCoordinates = 18;
        private const int NumberOfUavCoordinates = 3;
        private const int NumberOfShip3DPoint = 6;
        private double _pixelPerMm;
        private double _tParameter;
        private double _focalLengthmetres;
        private const double ConvertMetreToMm = 1000;
        private const double ConvertMmToMeters = 0.001;
        private Point _point;
        private Bitmap _image;

        //**************Temp*************
        private int _tempCounter = 0;
        int i = 0;

        #endregion
        
        public ImageSimulation(double[] cameraSetup)
        {
            _focalLengthMm = cameraSetup[0];
            _ccdWidthMm = cameraSetup[1];
            _ccdHeightMm = cameraSetup[2];
            _megaPixel = cameraSetup[3];
        }

        public void StartSimulation()
        {
            GetCalculationData();
            
            try
            {
                while (!FlightStatusSingleton.GetInstance().IsTouchdown)
                {
                    Thread.Sleep(33);
                    if(_listOfPositiveImagePixels.Count != 0)
                    {
                        DoClearData();
                    }

                    if (ImageDataSingleton.GetInstance().IsShipCoordinatesReceived)
                    {
                        lock (InstanceLocker)
                        {
                            _currentShipCoordinates = ImageDataSingleton.GetInstance().CurrentShipCoordinates;
                            _currentUavFocalPointCoordinates = ImageDataSingleton.GetInstance().CurrentUavCoordinates;
                        }
                    }

                    if (_currentShipCoordinates != null && _currentUavFocalPointCoordinates != null)
                    {
                        GenerateCurrentImageCoordinates();

                        //***********************Temp******************
                        Console.WriteLine("*****************************");

                        ConstructCurrentImage();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
                throw;
            }
        }

        private void GetCalculationData()
        {
            _pixelPerMm = Math.Sqrt((_megaPixel*1000000)/(_ccdWidthMm*_ccdHeightMm));
            _focalLengthmetres = _focalLengthMm * ConvertMmToMeters;
            _widthInPixels = Convert.ToInt32(_pixelPerMm*_ccdWidthMm);
            _heightInPixels = Convert.ToInt32(_pixelPerMm * _ccdHeightMm);
            _halfWidthInPixels = _widthInPixels/2;
            _halfHeightInPixels = _heightInPixels/2;
        }

        private void GenerateCurrentImageCoordinates()
        {
            try
            {
                if(_currentShipCoordinates.Length == NumberOfShipCoordinates &&
                    _currentUavFocalPointCoordinates.Length == NumberOfUavCoordinates)
                {
                    CalculateImageCoordinates();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
                throw;
            }
        }

        /*
        
        Given two points P and Q with coordinates (x,y,z) and (a,b,c) respectively
        then the parametric equation of the line segment from P to Q is given as
        x(t) = x + (a - x)t   eq 1
        y(t) = y + (b - y)t   ep 2
        z(t) = z + (c - z)t   eq 3
         
        as the projection plane is to be set at a distance equal to the focal length in front of the focal point
        and parallel to the x-z plane. This will give the resultant image the same aspect as the point in the world plane
        (i.e. it will not be inverted).This setup will unsure that the y coordinate in the image will always be the same
        and can then be dropped from the image. In this caes x in the world plane will represent y in the image plane
        and z in the world plane will represent x in the image plane.
        If Q is taken as the focal point then the x and z coordinates can be calculated for each point on the image
        given the world coordinates of that point. So;
         
        y(t) = b - f, then taking eq 2
        b - f = y + (b - y)t, therefore
        t = (b - f - y) / (b - y)   ep 4
        
        Using equation 4 for t in equations 1 & 3, x(t) and z(t) can now be calculated for the coordinates
        the ray trace insects the CCD plane from a given point in space. This calculations do not allow for 
        field of view which will be considered later.
        
        */

        public void CalculateImageCoordinates()
        {
            for (var i = 0; i < NumberOfShip3DPoint; i++)
            {
                var nextX = 0 + (i*3);
                var nextY = 1 + (i*3);
                var nextZ = 2 + (i*3);
                
                // The second double in the focal point array is the 'y' coordinate
                _tParameter = CalculateParameterT(_currentUavFocalPointCoordinates[1], 
                                               _currentShipCoordinates[nextY]);

                var mapX = CalculateImageCoordinate(_currentShipCoordinates[nextX],
                                                    _currentUavFocalPointCoordinates[0], _tParameter);
                var mapZ = CalculateImageCoordinate(_currentShipCoordinates[nextZ],
                                                    _currentUavFocalPointCoordinates[2], _tParameter);

                MapCoordinatesToPixels(mapX, mapZ);
            }
        }

        private double CalculateParameterT(double focalyValue, double pointyCoord)
        {
            var t = (focalyValue - _focalLengthmetres - pointyCoord) / (focalyValue - pointyCoord);

            return t;
        }

        private double CalculateImageCoordinate(double pointCoordinate, double cameraCoordinate, double t)
        {
            var coordinate = pointCoordinate + ((cameraCoordinate - pointCoordinate) * t);

            return coordinate;
        }

        private void MapCoordinatesToPixels(double coordinateXMetres, double coordinateZMetres)
        {

            var dx = (coordinateXMetres - _currentUavFocalPointCoordinates[0]) * ConvertMetreToMm * _pixelPerMm;
            var dy = (coordinateZMetres - _currentUavFocalPointCoordinates[2]) * ConvertMetreToMm * _pixelPerMm;

            _point.X = Convert.ToInt32(dx) + (_halfWidthInPixels);
            _point.Y = Convert.ToInt32(-dy) + (_halfHeightInPixels); // coordinate to pixel conversion


            if (_point.X >= 0 && _point.X < _widthInPixels && 
                _point.Y >= 0 && _point.Y < _heightInPixels)
            {
                _listOfPositiveImagePixels.Add(_point);

                //****************TEMP******************
                Console.WriteLine(_point.X + ", " + _point.Y);
            }
        }

        private void ConstructCurrentImage()
        {
            _image = new Bitmap(_widthInPixels, _heightInPixels);

            var bmData = _image.LockBits(new Rectangle(0, 0, _widthInPixels, _heightInPixels), 
                ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            var stride = bmData.Stride;
            System.IntPtr scan0 = bmData.Scan0;
            System.IntPtr scan1 = bmData.Scan0;

            unsafe
            {

                byte* pointer = (byte*)(void*)scan0;
                byte* pointerAssign = (byte*)(void*)scan1;

                for (int y = 0; y < _heightInPixels; ++y)
                {
                    for (int x = 0; x < _widthInPixels; ++x)
                    {
                        pointer[0] = 0;
                        pointer++;
                    }

                }

                foreach(var nextPoint in _listOfPositiveImagePixels)
                {
                    pointerAssign[nextPoint.Y*stride + nextPoint.X] = 255;
                    pointerAssign[nextPoint.Y * stride + nextPoint.X + 1] = 255;
                    pointerAssign[nextPoint.Y * stride + nextPoint.X - 1] = 255;
                    pointerAssign[(nextPoint.Y - 1) * stride + nextPoint.X] = 255;
                    pointerAssign[(nextPoint.Y + 1) * stride + nextPoint.X] = 255;
                }
            }

            _image.UnlockBits(bmData);

            //****************Temp************************
            if ((_tempCounter < 100) && ((i % 10) == 0))
            {
                _image.Save(@"C:\testImages\image(" + _tempCounter + ").jpg");
                
                _tempCounter++;
            }
            i++;
        }

        private void DoClearData()
        {
            _listOfPositiveImagePixels.Clear();
        }
    }
}
