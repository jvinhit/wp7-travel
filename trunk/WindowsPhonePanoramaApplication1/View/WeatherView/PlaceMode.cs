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
using System.Collections.Generic;

namespace WindowsPhonePanoramaApplication1
{
    public class PlaceMode : INotifyPropertyChanged
    {
        public static List<string> listKeyXML = new List<string>() { "city", "country", "woeid" };
        private string city;
   

        public string InforCollection
        {
            get { return String.Format("{0},{1},{2}", City, Country, Woeid); }
 
        }
        
        

        public string City
        {
            get { return city; }
            set 
            {
                if (value != city)
                {
                    city = value;
                    NotifyPropertyChanged("City");
                }
            }
        }
        private string country;

        public string Country
        {
            get { return country; }
            set
            {
                if (value != country)
                {
                    country = value;
                    NotifyPropertyChanged("Country");
                }
            }
        }
        private string woeid;

        public string Woeid
        {
            get { return woeid; }
            set
            {
                if (value != woeid)
                {
                    woeid = value;
                    NotifyPropertyChanged("Woeid");
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
