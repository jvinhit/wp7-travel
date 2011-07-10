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
using WindowsPhonePanoramaApplication1.Models.GoogleViewModel;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Serialization;
using GoogleFramework;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using System.Collections.ObjectModel;
using TravelObject;
using System.ComponentModel;
using WindowsPhonePanoramaApplication1.Models.News;


namespace WindowsPhonePanoramaApplication1.Views.GoogleMaps
{
  
    public partial class GoogleMaps : PhoneApplicationPage
    {
      
        PlaceObject placeObject;
        public GoogleMaps()
        {
            InitializeComponent();

            ApplicationBar.Opacity = 0.5;
            DataContext = GoogleViewModel.InstanceCurrent;
            //street.Opacity = 1;
            GoogleViewModel.InstanceCurrent.GotoCenterMap();
            //this.DataContext= placeObject;


      


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


        }

        private void appbar_button1_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/GoogleMaps/ChoosePlace.xaml", UriKind.Relative));
        }

        private void Pushpin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            Pushpin t = sender as Pushpin;

            foreach (PlaceObject temp in GoogleViewModel.InstanceCurrent._pushpins)
            {

                if (temp.geoCoor == t.Location)
                {
                    //placeObject = temp;
                    //NamePlace.Text = temp.Title;
                    //AdressPlace.Text = temp.Address;
                    //Description.Text = temp.ShorDescription;

                    ContentInfomation.DataContext = temp;

                    placeObject = new CafePlace();
                    placeObject = temp;
                    break;
                }
            }


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

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewsDetailViewModel.instance == null)
            {
                NewsDetailViewModel.instance = new CafePlace();
                NewsDetailViewModel.instance = placeObject;
                this.NavigationService.Navigate(new Uri("/Views/News/DetailItem.xaml", UriKind.Relative));
            }
            else
                this.NavigationService.GoBack();


        }


    }
}