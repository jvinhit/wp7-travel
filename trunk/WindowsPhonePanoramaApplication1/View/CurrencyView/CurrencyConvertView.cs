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
    public class CurrencyConvertView : INotifyPropertyChanged
    {
      
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

        private string resultValue;

        public string ResultValue
        {
            get { return resultValue; }
            set
            {
                if (value != resultValue)
                {
                    resultValue = value;
                    NotifyPropertyChanged("ResultValue");
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
