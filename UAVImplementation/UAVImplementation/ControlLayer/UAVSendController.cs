using UAVImplementation.ServiceLayer;
using UAVImplementation.BusinessLayer;
using System.Threading;

namespace UAVImplementation.ControlLayer
{
    public class UavSendController
    {
        private readonly string _ipAddress;
        private readonly int _port;

        UdpSender _udpSender;

        public UavSendController(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public void StartUdpSender()
        {
            var sender = new Thread(SenderThread);
            //sender.IsBackground = true;
            sender.Start();
            
        }

        public void SenderThread()
        {
            //_udpSender = new UdpSender(_ipAddress, _port);

            //while (!FlightStatusSingleton.GetInstance().IsTouchdown)
            //{
            //    //****************TEMP********************
            //    // Parameter temp.
            //    //_udpSender.StartSender(GlobalVarsTemp.TempCoord);
            //}
        }
    }
}
