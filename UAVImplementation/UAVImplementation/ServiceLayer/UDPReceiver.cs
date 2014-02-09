using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.ComponentModel;

namespace UAVImplementation.ServiceLayer
{
    class UDPReceiver : INotifyPropertyChanged
    {
        private Socket udpSocket;
        private byte[] buffer;
        private int port;

        private float[] floatArray = new float[1];

        private float[] shipCoordinates = new float[1];

        public float[] ShipCoordinates
        {
            get { return shipCoordinates; }
            set
            {
                this.shipCoordinates = value;
                NotifyPropertyChanged("ShipCoordinates");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UDPReceiver(int port)
        {
            this.port = port;
        }

        public void StartConnection()
        {
            floatArray[0] = -130.0f;

            udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            buffer = new byte[1024];

            EndPoint newClientEP = new IPEndPoint(IPAddress.Any, 0);
            udpSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, 
                                ref newClientEP, doReceiveCoordinates, udpSocket);
        }

        private void doReceiveCoordinates(IAsyncResult iAsynResult)
        {
            try
            {
                Socket receiveSocket = (Socket)iAsynResult.AsyncState;
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

                int dataSize = receiveSocket.EndReceiveFrom(iAsynResult, ref endPoint);

                byte[] data = new byte[dataSize];
                Array.Copy(buffer, data, dataSize);

                EndPoint newEndPoint = new IPEndPoint(IPAddress.Any, 0);
                udpSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, 
                                    ref newEndPoint, doReceiveCoordinates, udpSocket);

                floatArray = new float[data.Length / sizeof(float)];
                int index = 0;
                for (int i = 0; i < floatArray.Length; i++)
                {
                    floatArray[i] = BitConverter.ToSingle(data, index);
                    index += sizeof(float);
                }

                ShipCoordinates = floatArray;

            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
    }
}
