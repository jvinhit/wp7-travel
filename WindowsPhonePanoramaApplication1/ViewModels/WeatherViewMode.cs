using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WindowsPhonePanoramaApplication1
{
    public class WeatherViewMode : INotifyPropertyChanged
    {
        public static string _locationWOEID;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LocationWOEID
        {
            get
            {
                return _locationWOEID;
            }
            set
            {
                if (value != _locationWOEID)
                {
                    _locationWOEID = value;
                    NotifyPropertyChanged("LocationWOEID");
                }
            }
        }

        public static string _nameCity;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string NameCity
        {
            get
            {
                return _nameCity;
            }
            set
            {
                if (value != _nameCity)
                {
                    _nameCity = value;
                    NotifyPropertyChanged("NameCity");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
