using System.ComponentModel;

namespace UAVImplementation.BusinessLayer
{
    public class FlightStatusSingleton : INotifyPropertyChanged
    {
        #region Class fields

        private volatile static FlightStatusSingleton _uniqueInstance = new FlightStatusSingleton();
        private static readonly object InstanceLocker = new object();
        private bool _isTouchdown;

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
