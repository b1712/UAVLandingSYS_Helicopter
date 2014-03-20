using System.Collections.Generic;
using System.Drawing;
using UAVImplementation.BusinessLayer.CameraSimulator;


namespace UAVImplementation.BusinessLayer.ImageProcessor
{
    public class ImageCoordinates
    {
        private Bitmap _currentImage;
        private readonly List<Point> _coordinatePointsList = new List<Point>();
        //private Point _currentPoint = new Point();

        public Bitmap CurrentImage
        {
            get { return _currentImage; }
            set { _currentImage = value; }
        }

        public List<Point> GetImageCoordinates(Bitmap image)
        {
            #region Excluded from application 

            // Due to issues with concurrent locks. This decision is dicussed in the project document Chapter 10

            //CurrentImage = new Bitmap(image);

            //if (_coordinatePointsList.Count > 0)
            //{
            //    _coordinatePointsList.Clear();
            //}

            //var bmData2 = CurrentImage.LockBits(new Rectangle(0, 0, CurrentImage.Width, CurrentImage.Height),
            //                        ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

            //var stride = bmData2.Stride;
            //System.IntPtr scan1 = bmData2.Scan0;

            //unsafe
            //{
            //    byte* pointer = (byte*)(void*)scan1;

            //    for (int y = 0; y < CurrentImage.Height; ++y)
            //    {
            //        for (int x = 0; x < CurrentImage.Width; ++x)
            //        {
            //            if (pointer[0] > 10)
            //            {
            //                _currentPoint.X = x;
            //                _currentPoint.Y = y;
            //                _coordinatePointsList.Add(_currentPoint);
            //            }
            //            pointer++;
            //        }
            //    }
            //}

            //CurrentImage.UnlockBits(bmData2);

            #endregion

            return ImageDataSingleton.GetInstance().ListOfImageCoordinates;
        }
    }
}
