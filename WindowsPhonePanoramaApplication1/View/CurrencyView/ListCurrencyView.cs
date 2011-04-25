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
    public class ListCurrencyView : INotifyPropertyChanged
    {
        private string symbol;

        public string Symbol
        {
            get { return symbol; }


            set
            {
                if (value != symbol)
                {
                    symbol = value;
                    NotifyPropertyChanged("Symbol");
                }
            }
        }
        private string fullNameCurrency;

        public string FullNameCurrency
        {
            get { return fullNameCurrency; }
            set
            {
                if (value != fullNameCurrency)
                {
                    fullNameCurrency = value;
                    NotifyPropertyChanged("FullNameCurrency");
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
