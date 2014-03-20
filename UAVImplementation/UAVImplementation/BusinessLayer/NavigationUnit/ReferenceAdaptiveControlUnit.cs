using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using UAVImplementation.BusinessLayer.CameraSimulator;


namespace UAVImplementation.BusinessLayer.NavigationUnit
{
    public class ReferenceAdaptiveControlUnit
    {
        
        private List<Point> _imageCoordinatePointsList;
        private ApproachPositionOne _approachPositionOne;
        private bool _isApproachPositionOneAchieved;

        public ReferenceAdaptiveControlUnit()
        {
            while(!ImageDataSingleton.GetInstance().IsImageCoordinatesReceived)
            {
                Thread.Sleep(1000);
            }

            _isApproachPositionOneAchieved = false;
            _approachPositionOne = new ApproachPositionOne();
            StartControlUnit();
        }

        private void StartControlUnit()
        {
            while(!FlightStatusSingleton.GetInstance().IsTouchdown)
            {
                _imageCoordinatePointsList = ImageDataSingleton.GetInstance().ListOfImageCoordinates;

                switch (_imageCoordinatePointsList.Count)
                {
                    case 0:
                        // check for possible landing
                        if (!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired &&
                            FlightStatusSingleton.GetInstance().IsShipIntercepted)
                        {
                            GainAltitudeAndCentre();
                        }
                        else
                        {
                            InterceptShip();
                        }
                        break;
                    case 1:
                        // check for possible landing

                        FlightStatusSingleton.GetInstance().IsShipIntercepted = true;

                        if (!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired)
                        {
                            GainAltitudeAndCentre();
                        }
                        break;
                    case 2:
                        // check for possible landing

                        FlightStatusSingleton.GetInstance().IsShipIntercepted = true;

                        if (!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired)
                        {
                            GainAltitudeAndCentre();
                        }
                        break;
                    case 3:
                        // check for possible landing
                        if(!FlightStatusSingleton.GetInstance().IsSecondaryTargetAcquired)
                        {
                            FlightStatusSingleton.GetInstance().IsShipIntercepted = true;

                            if (!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired)
                            {
                                GainAltitudeAndCentre();
                            }
                        }
                        else
                        {
                            PerformFinalApproach();
                        }
                        
                        break;
                    case 4:

                        FlightStatusSingleton.GetInstance().IsShipIntercepted = true;

                        if (!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired)
                        {
                            GainAltitudeAndCentre();
                        }
                        break;
                    case 5:

                        FlightStatusSingleton.GetInstance().IsShipIntercepted = true;

                        if (!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired)
                        {
                            GainAltitudeAndCentre();
                        }

                        break;
                    case 6:

                        FlightStatusSingleton.GetInstance().IsShipIntercepted = true;

                        if(!FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired)
                        {
                            FlightStatusSingleton.GetInstance().IsPrimaryTargetAcquired = true;
                        }

                        PerformApproach();

                        break;

                    default:

                        FlightStatusSingleton.GetInstance().IsShipIntercepted = false;

                        GainAltitudeAndCentre();
                        break;

                }
            }
        }

        private void PerformApproach()
        {
            if(!_isApproachPositionOneAchieved)
            {
                _isApproachPositionOneAchieved =
                    _approachPositionOne.AchieveApproachPositionOne(_imageCoordinatePointsList);
            }


        }

        private void PerformFinalApproach()
        {
            
        }

        private void GainAltitudeAndCentre()
        {
            
        }

        private void InterceptShip()
        {
            
        }
    }
}
