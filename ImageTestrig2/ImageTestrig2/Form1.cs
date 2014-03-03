using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImageTestrig2
{
    public partial class Form1 : Form
    {
        
        private double fovDiagonalWidth;
        private double fovDiagonalHeight;
        private double fovAngleWidth;
        private double fovAngleHeight;
        private double halfChipWidth;
        private double halfChipHeight;
        private double focalLengthmm;
        private double focalLengthmetres;
        private string textFile;
        private readonly List<double> listOfWorldCoordinates = new List<double>();
        private readonly List<double> listOfImageCoordinates = new List<double>();
        private readonly List<Point> listOfPixels = new List<Point>();
        private int coordinateCount;
        private int masterIndex;
        private string currentCoordinateAsString = "";
        private double focalPointx;
        private double focalPointy;
        private double focalPointz;
        private double dx;
        private double dy;
        private const int numberOfPoints = 3;

        readonly Bitmap map = new Bitmap(2160, 1440);
        Point point;
        const int convertMetreTo_mm = 1000;
        
        public Form1()
        {
            InitializeComponent();

            focalPointx = double.Parse(txtBoxFocalPointx.Text);
            focalPointy = double.Parse(txtBoxFocalPointy.Text);
            focalPointz = double.Parse(txtBoxFocalPointz.Text);

            for (int i = 0; i < 2160; i++)
            {
                for (int j = 0; j < 1440; j++)
                {
                    map.SetPixel(i, j, Color.Black);
                }
            }

            pictureBox1.Width = 2160;
            pictureBox1.Height = 1440;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            textFile = System.IO.File.ReadAllText(@"C:\Users\Brian\Documents\GitHub\UAVLandingSYS_Helicopter\ImageTestrig2\TestData_Ship\SeaState6_Zero_Degrees_Full.txt");
            
            masterIndex = 0;
        }

        private void btnNextSet_Click(object sender, EventArgs e)
        {
            coordinateCount = 0;
            listOfWorldCoordinates.Clear();
            listOfImageCoordinates.Clear();
            listOfPixels.Clear();

            while (coordinateCount < 18 && masterIndex < textFile.Length)
            {
                if (textFile[masterIndex] == ',')
                {
                    listOfWorldCoordinates.Add(double.Parse(currentCoordinateAsString));
                    coordinateCount++;
                    currentCoordinateAsString = "";
                    masterIndex++;
                }

                currentCoordinateAsString += textFile[masterIndex];

                masterIndex++;
            }

            txt12x.Text = listOfWorldCoordinates[0].ToString();
            txt12y.Text = listOfWorldCoordinates[1].ToString();
            txt12z.Text = listOfWorldCoordinates[2].ToString();
            txt4x.Text = listOfWorldCoordinates[3].ToString();
            txt4y.Text = listOfWorldCoordinates[4].ToString();
            txt4z.Text = listOfWorldCoordinates[5].ToString();
            txt8x.Text = listOfWorldCoordinates[6].ToString();
            txt8y.Text = listOfWorldCoordinates[7].ToString();
            txt8z.Text = listOfWorldCoordinates[8].ToString();
        }

        private void btnFoV_Click(object sender, EventArgs e)
        {
            focalLengthmm = double.Parse(txtBoxFocalLength.Text);
            halfChipWidth = (double.Parse(txtBoxChipWidth.Text)) / 2;
            halfChipHeight = (double.Parse(txtBoxChipHeight.Text)) / 2;
            fovDiagonalWidth = findDiagonalLength(focalLengthmm, halfChipWidth);
            fovDiagonalHeight = findDiagonalLength(focalLengthmm, halfChipHeight);

            fovAngleWidth = radiansToDegrees(Math.Asin(halfChipWidth / fovDiagonalWidth)) * 2; // get full angle
            fovAngleWidth = Math.Round(fovAngleWidth, 2);

            fovAngleHeight = radiansToDegrees(Math.Asin(halfChipHeight / fovDiagonalHeight)) * 2; // get full angle
            fovAngleHeight = Math.Round(fovAngleHeight, 2);

            txtBoxFoVWidthAngle.Text = fovAngleWidth.ToString();
            txtBoxFoVHeightAngle.Text = fovAngleHeight.ToString();
        }

        private double radiansToDegrees(double radians)
        {
            double degrees = radians * 180 / Math.PI;

            return degrees;
        }

        private double findDiagonalLength(double side1, double side2)
        {
            double diagonal = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2));

            return diagonal;
        }

        private void btnXminus10_Click(object sender, EventArgs e)
        {
            focalPointx -= 10;
            txtBoxFocalPointx.Text = focalPointx.ToString();
        }

        private void btnYminus10_Click(object sender, EventArgs e)
        {
            focalPointy -= 10;
            txtBoxFocalPointy.Text = focalPointy.ToString();
        }

        private void btnZminus10_Click(object sender, EventArgs e)
        {
            focalPointz -= 10;
            txtBoxFocalPointz.Text = focalPointz.ToString();
        }

        private void btnXplus10_Click(object sender, EventArgs e)
        {
            focalPointx += 10;
            txtBoxFocalPointx.Text = focalPointx.ToString();
        }

        private void btnYplus10_Click(object sender, EventArgs e)
        {
            focalPointy += 10;
            txtBoxFocalPointy.Text = focalPointy.ToString();
        }

        private void btnZplus10_Click(object sender, EventArgs e)
        {
            focalPointz += 10;
            txtBoxFocalPointz.Text = focalPointz.ToString();
        }


        /// Given two points P and Q with coordinates (x,y,z) and (a,b,c) respectively
        /// then the parametric equation of the line segment from P to Q is given as
        /// x(t) = x + (a - x)t   eq 1
        /// y(t) = y + (b - y)t   ep 2
        /// z(t) = z + (c - z)t   eq 3
        /// 
        /// as the projection plane is to be set at a distance equal to the focal length in front of the focal point
        /// and parallel to the x-z plane. This will give the resultant image the same aspect as the point in the world plane
        /// (i.e. it will not be inverted).This setup will unsure that the y coordinate in the image will always be the same
        ///  and can then be dropped from the image. In this caes x in the world plane will represent y in the image plane
        ///  and z in the world plane will represent x in the image plane.
        /// If Q is taken as the focal point then the x and z coordinates can be calculated for each point on the image
        /// given the world coordinates of that point. So;
        /// 
        /// y(t) = b - f, then taking eq 2
        /// b - f = y + (b - y)t, therefore
        /// t = (b - f - y) / (b - y)   ep 4
        /// 
        /// Using equation 4 for t in equations 1 & 3, x(t) and z(t) can now be calculated for the coordinates
        /// the ray trace insects the CCD plane from a given point in space. This calculations do not allow for 
        /// field of view which will be considered later.
        /// 


        private void btnCalcImageCoord_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                double t = calculateParameterT(focalPointy, listOfWorldCoordinates[1 + (i * 3)]);

                mapCoordinatesToPixels(
                    (calculateImageCoordinate(listOfWorldCoordinates[0 + (i * 3)], focalPointx, t)),
                    (calculateImageCoordinate(listOfWorldCoordinates[2 + (i * 3)], focalPointz, t))
                    );
                pictureBox1.Image = map;
            }

            txtImageP1.Text = (listOfPixels[0].X.ToString() + ", " +
                                listOfPixels[0].Y.ToString());
            txtImageP2.Text = (listOfPixels[1].X.ToString() + ", " +
                                listOfPixels[1].Y.ToString());
            txtImageP3.Text = (listOfPixels[2].X.ToString() + ", " +
                                listOfPixels[2].Y.ToString());
        }

        private double calculateParameterT(double focalyValue, double pointyCoord)
        {
            focalLengthmm = double.Parse(txtBoxFocalLength.Text);
            focalLengthmetres = focalLengthmm / 1000.0;

            double t = (focalyValue - focalLengthmetres - pointyCoord) / (focalyValue - pointyCoord);

            return t;
        }

        private double calculateImageCoordinate(double pointCoordinate, double cameraCoordinate, double t)
        {
            double coordinate = pointCoordinate + ((cameraCoordinate - pointCoordinate) * t);
            Console.WriteLine("coordinate: " + coordinate);
            return coordinate;
        }

        private void mapCoordinatesToPixels(double worldx, double worldz)
        {
            // image width = 2160 pixels
            // image height = 1440 pixels
            // fullframe chip width = 36mm
            // fullframe chip height = 24mm
            // centre of chip = 18, 12
            // centre of image in pixels = 1080,720
            // centre of image in world coordinates (m) = UAVx, UAVz
            point = new Point();

            const double pixelPerMm = 1080/18; // map mm to pixel

            dx = (worldx - focalPointx) * convertMetreTo_mm * pixelPerMm;
            dy = (worldz - focalPointz) * convertMetreTo_mm * pixelPerMm;

            point.X = Convert.ToInt32(dx) + 1080;
            point.Y = Convert.ToInt32(-dy) + 720; // coordinate to pixel conversion

            listOfPixels.Add(point);

            Console.WriteLine(point.X + ", " + point.Y);

            if (point.X >= 0 && point.X < 2160 && point.Y >= 0 && point.Y < 1440)
            {
                map.SetPixel(50, 50, Color.White);
                map.SetPixel(point.X, point.Y, Color.White);
            }
        }

        private void btnCalculateSizes_Click(object sender, EventArgs e)
        {



        }

    }
}
