using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UAVImplementation.BusinessLayer
{
    public class FlightStatusSingleton
    {
        #region Class fields

        private volatile static FlightStatusSingleton uniqueInstance = new FlightStatusSingleton();

        private bool isTouchdown = false;

        #endregion

        #region Class Properties

        public bool IsTouchdown
        {
            get { return isTouchdown; }
            set { isTouchdown = value; }
        }

        #endregion

        private FlightStatusSingleton() { }

        public static FlightStatusSingleton getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new FlightStatusSingleton();
            }

            return uniqueInstance;
        }

        
    }
}
