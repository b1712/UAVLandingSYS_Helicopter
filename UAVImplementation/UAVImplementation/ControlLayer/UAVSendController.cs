using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UAVImplementation.ServiceLayer;
using UAVImplementation.BusinessLayer;
using System.Threading;

namespace UAVImplementation.ControlLayer
{
    public class UAVSendController
    {
        private string ipAddress;
        private int port;

        UDPSender udpSender;

        public UAVSendController(string ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public void startUDPSender()
        {
            udpSender = new UDPSender(ipAddress, port);

            //if (!FlightStatusSingleton.getInstance().IsTouchdown)
            while (!FlightStatusSingleton.getInstance().IsTouchdown)
            {
                //****************TEMP********************
                // Parameter temp.
                udpSender.startSender(GlobalVarsTemp.TempCoord);
            }
        }
    }
}
