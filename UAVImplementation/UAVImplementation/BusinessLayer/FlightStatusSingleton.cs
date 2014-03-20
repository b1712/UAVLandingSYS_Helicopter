using System.ComponentModel;

namespace UAVImplementation.BusinessLayer
{
    public class FlightStatusSingleton : INotifyPropertyChanged
    {
        #region Class fields

        private volatile static FlightStatusSingleton _uniqueInstance = new FlightStatusSingleton();
        private static readonly object InstanceLocker = new object();
        private bool _isTouchdown;
        private bool _isPrimaryTargetAcquired;
        private bool _isSecondaryTargetAcquired;
        private bool _isShipIntercepted;

        #endregion

        #region Class Properties

        public bool IsTouchdown
        {
            get { return _isTouchdown; }
            set
            {
                _isTouchdown = value;
                NotifyPropertyChanged("IsTouchdown");
            }
        }

        public bool IsPrimaryTargetAcquired
        {
            get { return _isPrimaryTargetAcquired; }
            set
            {
                _isPrimaryTargetAcquired = value;
                NotifyPropertyChanged("IsPrimaryTargetAcquired");
            }
        }

        public bool IsSecondaryTargetAcquired
        {
            get { return _isSecondaryTargetAcquired; }
            set
            {
                _isSecondaryTargetAcquired = value;
                NotifyPropertyChanged("IsSecondaryTargetAcquired");
            }
        }

        public bool IsShipIntercepted
        {
            get { return _isShipIntercepted; }
            set { _isShipIntercepted = value; }
        }

        #endregion

        #region Handler and Notify Method

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        private FlightStatusSingleton()
        {
            _isTouchdown = false;
            _isPrimaryTargetAcquired = false;
            _isSecondaryTargetAcquired = false;
        }

        public static FlightStatusSingleton GetInstance()
        {
            if (_uniqueInstance == null)
            {
                lock (InstanceLocker)
                {
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new FlightStatusSingleton();
                    }
                }
            }

            return _uniqueInstance;
        }
    }
}
