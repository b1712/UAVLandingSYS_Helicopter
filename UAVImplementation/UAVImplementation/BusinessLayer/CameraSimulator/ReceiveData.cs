using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UAVImplementation.BusinessLayer.CameraSimulator
{
    public class ReceiveData
    {
        //***************TEMP********************
        public float[] currentShipCoordinates;
        //private float[] currentShipCoordinates;



        //private float[] currentUAVCoordiates;

        //public float[] CurrentShipCoordinates
        //{
        //    get { return currentShipCoordinates; }
        //    set { currentShipCoordinates = value; }
        //}

        public void updateCoordinates(float[] shipCoordinates)
        {
            currentShipCoordinates = shipCoordinates;

            //foreach (float coord in currentShipCoordinates)
            //{
            //    Console.WriteLine(coord.ToString());
            //}

            //Console.WriteLine("*****************************************");


        }
    }
}
