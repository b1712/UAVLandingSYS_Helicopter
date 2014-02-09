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
        private int port = 9060;
        private float amount = -130.0f;
        UAV_UI ui = new UAV_UI();
       
        public UDPSender(string ipAddress, int port)
        {
            this.ipAddress = ipAddress;
            this.port = port;
        }

        public void startUDPSender()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            for (int i = 0; i < 500; i++)
            {
                amount = ui.shipCoordinates[1];


                    var floatArray1 = new float[] { amount };

                    var byteArray = new byte[floatArray1.Length * 4];
                    Buffer.BlockCopy(floatArray1, 0, byteArray, 0, byteArray.Length);

                    server.SendTo(byteArray, byteArray.Length, SocketFlags.None, ipep);
            }
        }
    }
}

