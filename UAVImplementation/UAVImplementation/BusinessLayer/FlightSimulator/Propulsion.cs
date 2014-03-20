using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using UAVImplementation.BusinessLayer.INSSimulator;

namespace UAVImplementation.BusinessLayer.FlightSimulator
{
    public class Propulsion
    {
        private double _xVector;
        private double _yVector;
        private double _zVector;
        private Stopwatch _timerFrameRate;

        public Propulsion()
        {
            _timerFrameRate = new Stopwatch();
            StartPropulsion();
        }

        private void StartPropulsion()
        {
            while(!FlightStatusSingleton.GetInstance().IsTouchdown)
            {
                _timerFrameRate.Reset();
                _timerFrameRate.Start();

                Update();

                if (_timerFrameRate.ElapsedMilliseconds < 33)
                {
                    Thread.Sleep((int)(33 - _timerFrameRate.ElapsedMilliseconds));
                }
            }
        }

        private void Update()
        {
            
        }
    }
}
