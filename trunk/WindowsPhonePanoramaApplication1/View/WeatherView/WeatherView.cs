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
    public class WeatherView : INotifyPropertyChanged
    {
        private string _locationWOEID;
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

        private string _nameCity;
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
        private Visibility _isContentGridVisibility;

        public Visibility IsContentGridVisibility
        {
            get { return _isContentGridVisibility; }
            set
            {
                if (value != _isContentGridVisibility)
                {
                    _isContentGridVisibility = value;
                    NotifyPropertyChanged("IsContentGridVisibility");
                }
            }
        }

        private string _lblCurrent_Text;
        public string LblCurrent_Text
        {
            get
            {
                return _lblCurrent_Text;
            }
            set
            {
                if (value != _lblCurrent_Text)
                {
                    _lblCurrent_Text = value;
                    NotifyPropertyChanged("LblCurrent_Text");
                }
            }
        }

        private string _lblCurrent_conditions_Text;

        public string LblCurrent_conditions_Text
        {
            get { return _lblCurrent_conditions_Text; }
            set
            {
                if (value != _lblCurrent_conditions_Text)
                {
                    _lblCurrent_conditions_Text = value;
                    NotifyPropertyChanged("LblCurrent_conditions_Text");
                }
            }
        }

        private ImageSource imgWeather1_Source;

        public ImageSource ImgWeather1_Source
        {
            get { return imgWeather1_Source; }
            set
            {
                if (value != imgWeather1_Source)
                {
                    imgWeather1_Source = value;
                    NotifyPropertyChanged("ImgWeather1_Source");
                }
            }
        }

        private ImageSource imgWeather2_Source;

        public ImageSource ImgWeather2_Source
        {
            get { return imgWeather2_Source; }
            set
            {
                if (value != imgWeather2_Source)
                {
                    imgWeather2_Source = value;
                    NotifyPropertyChanged("ImgWeather2_Source");
                }
            }
        }


        private ImageSource imgWeather3_Source;

        public ImageSource ImgWeather3_Source
        {
            get { return imgWeather3_Source; }
            set
            {
                if (value != imgWeather3_Source)
                {
                    imgWeather3_Source = value;
                    NotifyPropertyChanged("ImgWeather3_Source");
                }
            }
        }



        private string lblForecast1_Text;

        public string LblForecast1_Text
        {
            get { return lblForecast1_Text; }
            set
            {
                if (value != lblForecast1_Text)
                {
                    lblForecast1_Text = value;
                    NotifyPropertyChanged("LblForecast1_Text");
                }
            }
        }
        //lblForecast1_conditions.Text
        private string lblForecast1_conditions_Text;

        public string LblForecast1_conditions_Text
        {
            get { return lblForecast1_conditions_Text; }
            set
            {
                if (value != lblForecast1_conditions_Text)
                {
                    lblForecast1_conditions_Text = value;
                    NotifyPropertyChanged("LblForecast1_conditions_Text");
                }
            }
        }


      


        private string lblForecast2_Text;

        public string LblForecast2_Text
        {
            get { return lblForecast2_Text; }
            set
            {
                if (value != lblForecast2_Text)
                {
                    lblForecast2_Text = value;
                    NotifyPropertyChanged("LblForecast2_Text");
                }
            }
        }
        //lblForecast2_conditions.Text
        private string lblForecast2_conditions_Text;

        public string LblForecast2_conditions_Text
        {
            get { return lblForecast2_conditions_Text; }
            set
            {
                if (value != lblForecast2_conditions_Text)
                {
                    lblForecast2_conditions_Text = value;
                    NotifyPropertyChanged("LblForecast2_conditions_Text");
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
