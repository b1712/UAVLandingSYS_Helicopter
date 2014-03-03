using System;
using System.Net.Sockets;
using System.Net;

namespace UAVImplementation.ServiceLayer
{
    class UdpSender
    {
        private readonly string _ipAddress;
        private readonly int _port;
        private float _zCoord;
        private float _yCoord;
        private float _xCoord;
       
        public UdpSender(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public void StartSender(float[] coordinates)
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(_ipAddress), _port);
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            _xCoord = coordinates[3];
            _yCoord = coordinates[4];
            _zCoord = coordinates[5];

            var floatArray1 = new[] { _xCoord, _yCoord + 40.0f, _zCoord };

            var byteArray = new byte[floatArray1.Length * 4];
            Buffer.BlockCopy(floatArray1, 0, byteArray, 0, byteArray.Length);

            server.SendTo(byteArray, byteArray.Length, SocketFlags.None, ipEndPoint);

        }
    }
}

