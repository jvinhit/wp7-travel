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
    public class CurrencyConvertViewModel : INotifyPropertyChanged
    {
        private CurrencyConvertViewModel()
        {
            this.currencyFrom = "USD-U.S. Dollar";
            this.currencyTo = "VND-Vietnam Dong";

        }
        public static CurrencyConvertViewModel currentInstance = new CurrencyConvertViewModel();

        //private static bool isFromCurrency = true;
        private string currencyFrom;

        public string CurrencyFrom
        {
            get { return currencyFrom; }

            set
            {
                if (value != currencyFrom)
                {
                    currencyFrom = value;
                    NotifyPropertyChanged("CurrencyFrom");
                }
            }
        }
        private string currencyTo;

        public string CurrencyTo
        {
            get { return currencyTo; }
            set
            {
                if (value != currencyTo)
                {
                    currencyTo = value;
                    NotifyPropertyChanged("CurrencyTo");
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
