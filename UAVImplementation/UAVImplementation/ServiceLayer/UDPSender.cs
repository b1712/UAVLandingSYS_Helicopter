using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using UAVImplementation.PresentationLayer;

namespace UAVImplementation.ServiceLayer
{
    class UDPSender
    {
        private string ipAddress;
        private int port;
        private float zCoord;
        private float yCoord;
        private float xCoord;
       
        public UDPSender(string ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public void startSender(float[] coordinates)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            xCoord = coordinates[3];
            yCoord = coordinates[4];
            zCoord = coordinates[5];

            var floatArray1 = new float[] { xCoord, yCoord + 40.0f, zCoord };

            var byteArray = new byte[floatArray1.Length * 4];
            Buffer.BlockCopy(floatArray1, 0, byteArray, 0, byteArray.Length);

            server.SendTo(byteArray, byteArray.Length, SocketFlags.None, ipEndPoint);

        }
    }
}

