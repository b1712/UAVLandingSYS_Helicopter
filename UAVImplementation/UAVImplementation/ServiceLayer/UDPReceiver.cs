using System;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace UAVImplementation.ServiceLayer
{
    class UdpReceiver : INotifyPropertyChanged
    {
        #region fields

        private Socket _udpSocket;
        private byte[] _buffer;
        private readonly int _port;
        private float[] _floatArray = new float[18];
        private double[] _shipCoordinates = new double[18];
        private readonly double[] _tempArray = new double[18];
        private bool _isReceivingCoordinates;

        #endregion

        #region Class Properties

        public double[] ShipCoordinates
        {
            get { return _shipCoordinates; }
            set
            {
                _shipCoordinates = value;
                NotifyPropertyChanged("ShipCoordinates");
            }
        }

        public bool IsReceivingCoordinates
        {
            get { return _isReceivingCoordinates; }
            set 
            { 
                _isReceivingCoordinates = value;
                NotifyPropertyChanged("IsReceivingCoordinates");
            }
        }

        #endregion

        #region Handler and Notify Method

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 

        #endregion

        public UdpReceiver(int port)
        {
            _port = port;
        }

        public void StartConnection()
        {
            try
            {
                _udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _udpSocket.Bind(new IPEndPoint(IPAddress.Any, _port));
                _buffer = new byte[1024];

                EndPoint newClientEp = new IPEndPoint(IPAddress.Any, 0);
                _udpSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None,
                                    ref newClientEp, DoReceiveCoordinates, _udpSocket);
            }
            catch (SocketException socketEx)
            {
                Console.WriteLine("A socket error in Receiver startup: " + socketEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("A general error in Receiver startup: " + ex.Message);
                throw;
            }
        }

        private void DoReceiveCoordinates(IAsyncResult iAsynResult)
        {
            try
            {
                var receiveSocket = (Socket)iAsynResult.AsyncState;
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

                var dataSize = receiveSocket.EndReceiveFrom(iAsynResult, ref endPoint);

                var data = new byte[dataSize];
                Array.Copy(_buffer, data, dataSize);

                EndPoint newEndPoint = new IPEndPoint(IPAddress.Any, 0);
                _udpSocket.BeginReceiveFrom(_buffer, 0, _buffer.Length, SocketFlags.None, 
                                    ref newEndPoint, DoReceiveCoordinates, _udpSocket);

                _floatArray = new float[data.Length / sizeof(float)];

                var index = 0;

                for (var i = 0; i < _floatArray.Length; i++)
                {
                    _floatArray[i] = BitConverter.ToSingle(data, index);
                    index += sizeof(float);
                }

                if (!IsReceivingCoordinates)
                {
                    IsReceivingCoordinates = true;
                }

                for (var i = 0; i < _floatArray.Length; i++)
                {
                    _tempArray[i] = Convert.ToDouble(_floatArray[i]);
                }
                
                // tempArray is used here because any partial changes to the ShipCoordinates array 
                // will fire the Property Changed event.

                ShipCoordinates = _tempArray;
            }
            catch (ObjectDisposedException objectEx)
            {
                Console.WriteLine("An error with Receive method: " + objectEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("A general error with Receive method: " + ex.Message);
                throw;
            }
        }
    }
}
