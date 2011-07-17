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
using System.Collections.ObjectModel;
using TravelObject;
using System.Device.Location;

namespace WindowsPhonePanoramaApplication1.Views.GoogleMaps
{
    public partial class ChoosePlace : PhoneApplicationPage
    {
        
        public ChoosePlace()
        {
            InitializeComponent();
            this.DataContext = GoogleViewModel.InstanceCurrent.placeKind;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<PlaceObject> listCoffee = new ObservableCollection<PlaceObject>();
            GoogleViewModel.InstanceCurrent._pushpins.Clear();
        
            
            foreach (var tempIndex in listCoffee.ToList<PlaceObject>())
            {
                GoogleViewModel.InstanceCurrent._pushpins.Add(tempIndex);
            }
            NavigationService.GoBack();
        }
    }
}