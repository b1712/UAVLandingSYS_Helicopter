using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAVImplementation.BusinessLayer.CameraSimulator;
using System.Reflection;

namespace TestBusinessLayer
{
    [TestClass]
    public class TestImageSimulation
    {
        /// <summary>
        /// Test GetCalculationData method to check field _pixelPerMm
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

            const double expected = 34.02;

            Assert.AreEqual(expected, actual, 0.005);
        }

        /// <summary>
        /// Test GetCalculationData method to check field _focalLengthmetres
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

            const double expected = 0.03;

            Assert.AreEqual(expected, actual, 0.005);
        }

        /// <summary>
        /// Test GetCalculationData method to check field _widthInPixels
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

            const int expected = 1225;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test GetCalculationData method to check field _heightInPixels
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

            const int expected = 816;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// This test is run to test the CalculateParameterT method with the actual camera data with y values for
        /// 2 points = {4,2}
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

            const double expected = 0.985;

            Assert.AreEqual(expected, actual, 0.005);

        }

        /// <summary>
        /// This test is run to test the CalculateImageCoordinate with data from Example 11 page 634 of
        /// Calculus with Analytic Geometry by John B. Fraleigh
        /// given 2 points to points (-1,3,2) and (3,1,-1), find a point one-third of the way along the line
        /// segment. Example result t= 1/3 and new point = (1/3,7/3,1)
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

            const double expectedY = 2.333;

            //Check Z values
            var actualZ = (double)typeof(ImageSimulation).GetMethod("CalculateImageCoordinate",
                        BindingFlags.NonPublic | BindingFlags.Instance).Invoke(target, new object[] { 2, -1, 0.333 });

            const double expectedZ = 1;

            Assert.AreEqual(expectedX, actualX, 0.005);
            Assert.AreEqual(expectedY, actualY, 0.005);
            Assert.AreEqual(expectedZ, actualZ, 0.005);

        }
        
    }
}