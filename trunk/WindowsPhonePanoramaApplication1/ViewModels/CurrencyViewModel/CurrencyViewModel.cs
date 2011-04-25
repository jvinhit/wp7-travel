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
using System.Collections.ObjectModel;

namespace WindowsPhonePanoramaApplication1.ViewModels.CurrencyViewModel
{
    public class CurrencyViewModel : ViewModelBase
    {
        public ObservableCollection<CurrencyConvertView> CurrencyList { get; private set; }
        private CurrencyViewModel()
        {
            this.CurrencyList=new ObservableCollection<CurrencyConvertView>();
            this.CurrencyList.Add(new CurrencyConvertView() { CurrencyFrom = "USD-U.S. Dollar", CurrencyTo = "VND-Vietnam Dong",ResultValue="" });
 
        }
        public static CurrencyViewModel instanceCurrent = new CurrencyViewModel();

        public void ConvertResult(int amount, string fromCurrency, string toCurrency)
        {
            //http://www.google.com/ig/calculator?hl=en&q=$amount$to_Currency.%3D%3F$to_Currency"
            WebClient wc1 = new WebClient();
            wc1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc1_DownloadStringCompleted);

            Uri stringTemp = new Uri(string.Format("http://www.google.com/ig/calculator?hl=en&q={0}{1}%3D%3F{2}", amount, fromCurrency, toCurrency));
            wc1.DownloadStringAsync(stringTemp);
        }

        void wc1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string result = e.Result.ToString();
            result = result.Split(',')[1];
            result = result.Split('"')[1].Trim();
            result = result.Replace('�', ' ');
            if (result.Trim().Length == 0)
                result = "Not Support This Convert";
            this.CurrencyList[0].ResultValue = result;

        }


    }
}
