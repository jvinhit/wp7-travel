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
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace WindowsPhonePanoramaApplication1.Views
{
    public partial class WeatherView : PhoneApplicationPage
    {
        
        public WeatherView()
        {
            InitializeComponent();
            //DataContext = App.ViewModel;
            DataContext = WeatherViewMode.weatherInstance.ListWeatherInstance[0];
            //this.textBlockListTitle.DataContext = WeatherViewMode.weatherInstance;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }
        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }
        ~WeatherView()
        {
            WeatherViewMode.weatherInstance.SaveIntoDatabase();
        }
      

        private void btnDelete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //"/Views/WeatherViews/WeatherView.xaml"
            this.NavigationService.Navigate(new Uri(((Image)sender).Tag.ToString(), UriKind.Relative));
        }

        private void btnAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //UpdateWeather();
            //if (WP7Shared.Network.InternetIsAvailable())
                WeatherViewMode.weatherInstance.UpdateWeather();

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            WeatherViewMode.weatherInstance.UpdateWeather();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/WeatherViews/ModifyPlace.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


    }
}