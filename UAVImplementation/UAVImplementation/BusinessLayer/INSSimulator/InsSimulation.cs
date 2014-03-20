using System.ComponentModel;
using System;
using System.Threading;

namespace UAVImplementation.BusinessLayer.INSSimulator
{
    public class InsSimulation : INotifyPropertyChanged
    {
        #region fields

        private double[] _currentUavCoordinates;

        //************TEMP**********
        //private bool _running;

        #endregion

        #region Class Properties

        public double[] CurrentUavCoordinates

        {
            get { return _currentUavCoordinates; }
            set
            {
                _currentUavCoordinates = value;
                NotifyPropertyChanged("CurrentUavCoordinates");
            }
        }

        #endregion

        #region Handler and Notify Method

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public InsSimulation()
        {
            //CurrentUavCoordinates = startCoordinates;
            ////Console.WriteLine("I am the InsSim");
            //Thread.Sleep(3000);
            //Console.WriteLine("I am the InsSim 3000");
            //FlightStatusSingleton.GetInstance().IsTouchdown = true;
        }

        public void PostCoordinates(double[] currentCoordinates)
        {
            CurrentUavCoordinates = currentCoordinates;

            //*************Temp*******************
            //_running = true;
        }

        //*************Temp*******************
        public void UpdateCoord()
        {
            double[] temp = CurrentUavCoordinates;
            //while (!FlightStatusSingleton.GetInstance().IsTouchdown)
            //{
            //    //if (_running == true && temp[1] > 30)
            //    //{
            //    //    Thread.Sleep(400);
                    
            //    //    temp[1]--;
            //    //    CurrentUavCoordinates = temp;
            //    //    Console.WriteLine(temp[1].ToString());
            //    //}
            //}
        }
        
    }
}
