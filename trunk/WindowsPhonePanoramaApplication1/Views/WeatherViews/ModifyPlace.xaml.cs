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
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace WindowsPhonePanoramaApplication1.Views.WeatherViews
{
    public partial class ModifyPlace : PhoneApplicationPage
    {
        


        public ModifyPlace()
        {
            InitializeComponent();
            
            //this.Items1.Add(new PlaceMode() { City = "nguyentan", Country = "coudnadfa", Woeid = "asdfa" });
            this.DataContext = ModifyPlaceViewModel.instanceCurrent;

        }

        private void textBox1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBox1.SelectAll();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            string temp = this.textBox1.Text.ToString().Trim().Replace(' ', '+');
            ModifyPlaceViewModel.instanceCurrent.FindPlace(temp);
            //FindPlace(temp);

        }

        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //WeatherViewMode.weatherInstance.LocationWOEID = ((Image)sender).Tag.ToString().Split(',')[2];
            //WeatherViewMode.weatherInstance.NameCity = ((Image)sender).Tag.ToString().Split(',')[0];
            ModifyPlaceViewModel.instanceCurrent.UpdatePlace(((Image)sender).Tag.ToString().Split(',')[2],((Image)sender).Tag.ToString().Split(',')[0]);

            
     
            this.NavigationService.Navigate(new Uri("/Views/WeatherViews/WeatherView.xaml", UriKind.Relative));
            
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            textBox1.SelectAll();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

       
    }
}