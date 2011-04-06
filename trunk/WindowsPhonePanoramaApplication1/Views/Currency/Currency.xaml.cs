using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace WindowsPhonePanoramaApplication1.Views.Currency
{
    public partial class Currency : PhoneApplicationPage
    {
        //public ObservableCollection<CurrencyConvertViewModel> ItemsBinding { get; private set; }

        public Currency()
        {
            InitializeComponent();
            //this.cmbCurrFrom.ItemsSource = arrayCurrency.ToList<string>();
            //this.ItemsBinding = new ObservableCollection<CurrencyConvertViewModel>();

            this.textBox2.DataContext = CurrencyConvertViewModel.currentInstance;
            this.textBox3.DataContext = CurrencyConvertViewModel.currentInstance;
        }

        //private void btnConvert_Click(object sender, RoutedEventArgs e)
        //{
        //    ConvertResult(1, "USD", "VND");
        //}
        private void ConvertResult(int amount, string fromCurrency, string toCurrency)
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
            result=result.Split(',')[1];
            result=result.Split('"')[1].Trim();
            result=result.Replace('�', ' ');
            this.textBlock4.Text = result;
            
        }

        private void textBox2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Currency/CurrencyModify.xaml?isFromCurrency=1", UriKind.Relative));
        }

        private void textBox3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/Currency/CurrencyModify.xaml?isFromCurrency=0", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConvertResult(int.Parse(this.textBox1.Text), this.textBox2.Text.Substring(0, 3), this.textBox3.Text.Substring(0, 3));

        }


    }
}




