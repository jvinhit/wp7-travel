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

namespace WindowsPhoneApplication1.Presenter
{
    public partial class Home : PhoneApplicationPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            this.NavigationService.Navigate(new Uri(@"/Presenter/Maps/Map1_Search.xaml", UriKind.Relative)); 

        }

        private void textBlock2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"/Presenter/Facebook/Facebook_home.xaml", UriKind.Relative)); 
        }

        private void textBlock3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"/Presenter/Weather/Weather.xaml", UriKind.Relative));

        }

        private void textBlock4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri(@"/Presenter/Money/Money.xaml", UriKind.Relative));
            this.NavigationService.Navigate(new Uri(@"/Presenter/Dolar/Page1.xaml", UriKind.Relative));
        }

        private void textBlock5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"/Presenter/FindTeam/FindTeam.xaml", UriKind.Relative));
        }
    }
}