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
using WindowsPhonePanoramaApplication1.ViewModels.GoogleViewModel;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Serialization;
using GoogleFramework;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using System.Collections.ObjectModel;
using TravelObject;
using System.ComponentModel;


namespace WindowsPhonePanoramaApplication1.ViewPages.GoogleMaps
{
    public partial class GoogleMaps : PhoneApplicationPage
    {

        public GoogleMaps()
        {
            InitializeComponent();
            //street.Visibility = Visibility.Visible;
            //st.IsChecked = true;

            //hybrid.Visibility = Visibility.Collapsed;
            //satellite.Visibility = Visibility.Collapsed;
            //street.Visibility = Visibility.Visible;
            //physical.Visibility = Visibility.Collapsed;
            //wateroverlay.Visibility = Visibility.Collapsed;

            //GoogleViewModel.LoadFromdDatabase(ref googlemap);
            //googlemap.SetView(MarkOnMap.Current, MarkOnMap.ZoomLevelCurrent);
            ApplicationBar.Opacity = 0.5;



            //googlemap.reso

            //this.googlemap.DataContext = GoogleViewModel.listPlacePushpin;
            DataContext = GoogleViewModel.InstanceCurrent;
            //street.Opacity = 1;
            GoogleViewModel.InstanceCurrent.GotoCenterMap();

        }
        ~GoogleMaps()
        {
            //GoogleViewModel.SaveIntoDatabase(googlemap);
            //GoogleViewModel.SaveIntoDatabase(googlemap);


        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            ////base.OnNavigatedTo(e);
            //GoogleViewModel.UpdatePushPin(ref googlemap);

            ////create a new pushpin---
            //Pushpin pin = new Pushpin();

            ////set the location for the pushpin---
            //pin.Location = new GeoCoordinate(10.324, 106.654);

            ////add the pushpin to the map---
            //googlemap.Children.Add(pin);

        }
       

        private void ButtonZoomIn_Click(object sender, RoutedEventArgs e)
        {
            googlemap.ZoomLevel++;
        }

        private void ButtonZoomOut_Click(object sender, RoutedEventArgs e)
        {
            googlemap.ZoomLevel--;
        }

        private void googlemap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //Point p = e.GetPosition(this.googlemap);
            //GeoCoordinate geo = new GeoCoordinate();
            //geo = googlemap.ViewportPointToLocation(p);
            //googlemap.ZoomLevel = 17;
            //googlemap.Center = geo;
            //create a new pushpin---
            //Pushpin pin = new Pushpin();

            //set the location for the pushpin---
            //pin.Location = geo;

            //add the pushpin to the map---
            //googlemap.Children.Add(pin);


            ////create a new pushpin---
            //Pushpin pin = new Pushpin();

            ////set the location for the pushpin---
            //pin.Location = new GeoCoordinate(10.324, 106.654);

            ////add the pushpin to the map---
            //googlemap.Children.Add(pin);


        }

        private void appbar_button1_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ViewPages/GoogleMaps/ChoosePlace.xaml", UriKind.Relative));
        }

        private void Pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("asfdA");
            ShowInformation.Visibility = Visibility.Visible;
            
            

        }

        private void appbar_button2_Click(object sender, EventArgs e)
        {
            ShowInformation.Visibility = Visibility.Collapsed;
            GoogleViewModel.InstanceCurrent.GotoCenterMap();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowInformation.Visibility = Visibility.Collapsed;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


    }
}