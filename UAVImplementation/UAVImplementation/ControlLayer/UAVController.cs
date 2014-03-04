using System;
using System.Threading;
using UAVImplementation.BusinessLayer.INSSimulator;
using UAVImplementation.BusinessLayer.CameraSimulator;
using UAVImplementation.BusinessLayer.NavigationUnit;
using UAVImplementation.BusinessLayer.ImageProcessor;

namespace UAVImplementation.ControlLayer
{
    public class UavController
    {
        private readonly double[] _startPoint;
        private volatile InsSimulation _insSimulation;
        private ImageSimulation _imageSimulation;
        private double[] _cameraSetup;

        public UavController(double[] startPoint)
        {
            _startPoint = startPoint;
        }

        public void StartIntercept(double[] cameraSetup)
        {
            _cameraSetup = cameraSetup;

            try
            {
                var startInsSimulator = new Thread(StartInsAndPassInstance);
                startInsSimulator.Start();
                var startImageGeneration = new Thread(GenerateImages);
                startImageGeneration.Start();

                var startprocessImages = new Thread(ProcessImages);
                startprocessImages.Start();

                var startNavigation = new Thread(StartNavigation);
                startNavigation.Start();

                //SetupInsHandler();
            }
            catch (ThreadAbortException threadEx)
            {
                Console.WriteLine("An error occured starting a thread: " + threadEx);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
                throw;
            }
            
        }

        private void StartInsAndPassInstance()
        {
            try
            {
                _insSimulation = new InsSimulation();
                ImageDataSingleton.GetInstance().SetupInsListener(_insSimulation);
                _insSimulation.PostCoordinates(_startPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
                throw;
            }
        }

        private void GenerateImages()
        {
            try
            {
                _imageSimulation = new ImageSimulation(_cameraSetup);
                _imageSimulation.StartSimulation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
                throw;
            }
        }

        private void ProcessImages()
        {
            new ImageProcessorSimulation();
        }

        //private void SetupInsHandler()
        //{
        //    //try
        //    //{
        //    //    ImageDataSingleton.GetInstance().SetupInsListener(_insSimulation);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine("An error occured trying to retrieve the instance of the InsSimulation: " + ex);
        //    //    throw;
        //    //}
        //}

        private void StartNavigation()
        {
            //try
            //{
                new ReferenceAdaptiveControlUnit();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("An Error occured in " + ex.TargetSite + "..." + ex.Message);
            //    throw;
            //}
        }
    }
}