using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using UAVImplementation.BusinessLayer.CameraSimulator;
using System.Drawing;

namespace UAVImplementation.BusinessLayer.ImageProcessor
{
    public class ImageProcessSimulation : INotifyPropertyChanged
    {
        private ImageCoordinates _imageCoordinates;
        private List<Point> _coordinatePointsList;
        private Stopwatch _timerFrameRate;

        public ImageProcessSimulation()
        {
            _timerFrameRate = new Stopwatch();
            _imageCoordinates = new ImageCoordinates();
        }

        public List<Point> CoordinatePointsList
        {
            get { return _coordinatePointsList; }
            set
            {
                _coordinatePointsList = value;
                NotifyPropertyChanged("CoordinatePointsList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            //foreach (Point p in _coordinatePointsList)
            //{
            //    Console.Write("(" + p.X + ", " + p.Y + ") ");
            //}
            //Console.WriteLine();

            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void StartProcessor()
        {
            while (!FlightStatusSingleton.GetInstance().IsTouchdown)
            {
                while (!ImageDataSingleton.GetInstance().IsCurrentImageReceived)
                {
                    Thread.Sleep(1000);
                }
                
                    try
                    {
                        _timerFrameRate.Reset();
                        _timerFrameRate.Start();

                        CoordinatePointsList = _imageCoordinates.GetImageCoordinates(ImageDataSingleton.GetInstance().CurrentImage);

                        if (_timerFrameRate.ElapsedMilliseconds < 33)
                        {
                            Thread.Sleep((int)(33 - _timerFrameRate.ElapsedMilliseconds));
                        }


                        //*************Temp**************
                        //Console.WriteLine("Time = " + _timerFrameRate.ElapsedMilliseconds);

                        //foreach (Point p in _coordinatePointsList)
                        //{
                        //    Console.Write("(" + p.X + ", " + p.Y + ") ");
                        //}
                        //Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
                        throw;
                    }


                
            }
        }
    }
}
