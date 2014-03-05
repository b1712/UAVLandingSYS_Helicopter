using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAVImplementation.BusinessLayer.CameraSimulator;
using System.Reflection;
using System.Collections.Generic;

namespace TestBusinessLayer
{
    [TestClass]
    public class TestImageSimulation
    {
        /// <summary>
        /// Test GetCalculationData method to check field _pixelPerMm using reflection to access the private
        /// method and private field
        /// </summary>
        [TestMethod]
        public void TestGetCalculationData1()
        {
            var cameraSetup = new double[] { 30, 36, 24, 1 };

            var target = new ImageSimulation(cameraSetup);

            typeof(ImageSimulation).GetMethod("GetCalculationData",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            var actual = (double)typeof(ImageSimulation).GetField("_pixelPerMm",
                        BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            double expected = 34.02;

            Assert.AreEqual(expected, actual, 0.005);
        }

        /// <summary>
        /// Test GetCalculationData method to check field _focalLengthmetres using reflection to access the private
        /// method and private field
        /// </summary>
        [TestMethod]
        public void TestGetCalculationData2()
        {
            var cameraSetup = new double[] { 30, 36, 24, 1 };

            var target = new ImageSimulation(cameraSetup);

            typeof(ImageSimulation).GetMethod("GetCalculationData",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            var actual = (double)typeof(ImageSimulation).GetField("_focalLengthmetres",
                        BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            double expected = 0.03;

            Assert.AreEqual(expected, actual, 0.005);
        }

        /// <summary>
        /// Test GetCalculationData method to check field _widthInPixels using reflection to access the private
        /// method and private field
        /// </summary>
        [TestMethod]
        public void TestGetCalculationData3()
        {
            var cameraSetup = new double[] { 30, 36, 24, 1 };

            var target = new ImageSimulation(cameraSetup);

            typeof(ImageSimulation).GetMethod("GetCalculationData",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            var actual = (int)typeof(ImageSimulation).GetField("_widthInPixels",
                        BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            int expected = 1225;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test GetCalculationData method to check field _heightInPixels using reflection to access the private
        /// method and private field
        /// </summary>
        [TestMethod]
        public void TestGetCalculationData4()
        {
            var cameraSetup = new double[] { 30, 36, 24, 1 };

            var target = new ImageSimulation(cameraSetup);

            typeof(ImageSimulation).GetMethod("GetCalculationData",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            var actual = (int)typeof(ImageSimulation).GetField("_heightInPixels",
                        BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            int expected = 816;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test is run to test the CalculateParameterT method with the actual camera data with y values for
        /// 2 points = {4,2}. Reflection is used to access the prerequisite private method GetCalculationData()
        /// and the target method TestCalculateParameterT() and also the private field
        /// </summary>
        [TestMethod]
        public void TestCalculateParameterT()
        {
            var cameraSetup = new double[] { 30, 36, 24, 1 };

            var target = new ImageSimulation(cameraSetup);

            typeof(ImageSimulation).GetMethod("GetCalculationData",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            var actual = (double)typeof(ImageSimulation).GetMethod("CalculateParameterT",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, new object[] { 4, 2 });

            double expected = 0.985;

            Assert.AreEqual(expected, actual, 0.005);

        }

        /// <summary>
        /// This test is run to test the CalculateImageCoordinate with data from Example 11 page 634 of
        /// Calculus with Analytic Geometry by John B. Fraleigh
        /// given 2 points to points (-1,3,2) and (3,1,-1), find a point one-third of the way along the line
        /// segment. Example result t= 1/3 and new point = (1/3,7/3,1). Reflection is used here to access the
        /// CalculateImageCoordinate().
        /// </summary>
        [TestMethod]
        public void TestCalculateImageCoordinate()
        {
            //setup with dummy data for constructor
            var cameraSetup = new double[] { 1,1,1,1 };

            var target = new ImageSimulation(cameraSetup);

            //Check X values
            var actualX = (double)typeof(ImageSimulation).GetMethod("CalculateImageCoordinate",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, new object[] { -1, 3, 0.333 });

            const double expectedX = 0.333;

            //Check Y values
            var actualY = (double)typeof(ImageSimulation).GetMethod("CalculateImageCoordinate",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, new object[] { 3, 1, 0.333 });

            double expectedY = 2.333;

            //Check Z values
            var actualZ = (double)typeof(ImageSimulation).GetMethod("CalculateImageCoordinate",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, new object[] { 2, -1, 0.333 });

            double expectedZ = 1;

            Assert.AreEqual(expectedX, actualX, 0.005);
            Assert.AreEqual(expectedY, actualY, 0.005);
            Assert.AreEqual(expectedZ, actualZ, 0.005);

        }

        /// <summary>
        /// This test is run to test the MapCoordinatesToPixels method with test data (2,0,-1) and focal point 
        /// at (1,50,0) with the normal setup for the camera. The expected results for the image (x,y) pixel 
        /// coordinates is (646,442). To run the test the private field that is normally populated by a 
        /// PropertyChanged event handler has its data hard coded with refection.
        /// </summary>
        [TestMethod]
        public void TestMapCoordinatesToPixels()
        {
            var cameraSetup = new double[] { 30, 36, 24, 1 };

            var target = new ImageSimulation(cameraSetup);

            typeof(ImageSimulation).GetMethod("GetCalculationData",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, null);

            var tempFocalPointCoordinates = new double[]{1,50,0}; // passed to private method

            typeof(ImageSimulation).GetField("_currentUavFocalPointCoordinates",
                        BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target,tempFocalPointCoordinates);

            typeof(ImageSimulation).GetMethod("MapCoordinatesToPixels",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, new object[] { 1.001, -0.001});

            var coordinateCollection = (List<Point>) typeof(ImageSimulation).GetField("_listOfPositiveImagePixels",
                        BindingFlags.NonPublic | BindingFlags.Instance).GetValue(target);

            Point point = coordinateCollection[0];

            var actualX = point.X;
            int expectedX = 646;

            var actualY = point.Y;
            int expectedY = 442;

            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }
    }
}