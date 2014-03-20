using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace UAVImplementation.BusinessLayer.NavigationUnit
{
    public class ApproachPositionOne
    {
        private List<Point> _imageCoordinatePointsList;
        
        public bool AchieveApproachPositionOne(List<Point> imageCoordinatePointsList)
        {
            _imageCoordinatePointsList = imageCoordinatePointsList;

            return true;
        }
    }
}
