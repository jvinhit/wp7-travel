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
using WindowsPhonePanoramaApplication1.ViewModels.CurrencyViewModel;

namespace WindowsPhonePanoramaApplication1.ViewPages.Currency
{
    public partial class Currency : PhoneApplicationPage
    {
        //public ObservableCollection<CurrencyConvertViewModel> ItemsBinding { get; private set; }

        public Currency()
        {
            InitializeComponent();
         
            this.DataContext = CurrencyViewModel.instanceCurrent.CurrencyList[0];
        }

        //private void btnConvert_Click(object sender, RoutedEventArgs e)
        //{
        //    ConvertResult(1, "USD", "VND");
        //}
        

        private void textBox2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ViewPages/Currency/CurrencyModify.xaml?isFromCurrency=1", UriKind.Relative));
        }

        private void textBox3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ViewPages/Currency/CurrencyModify.xaml?isFromCurrency=0", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CurrencyViewModel.instanceCurrent.ConvertResult(int.Parse(this.textBox1.Text), this.textBox2.Text.Substring(0, 3), this.textBox3.Text.Substring(0, 3));

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


    }
}




