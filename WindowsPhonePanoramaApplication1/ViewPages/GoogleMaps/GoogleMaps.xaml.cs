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
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace WindowsPhonePanoramaApplication1.ViewPages.GoogleMaps
{
    public partial class GoogleMaps : PhoneApplicationPage
    {
      
        public GoogleMaps()
        {
            InitializeComponent();
            street.Visibility = Visibility.Visible;
            //st.IsChecked = true;

            hybrid.Visibility = Visibility.Collapsed;
            satellite.Visibility = Visibility.Collapsed;
            street.Visibility = Visibility.Visible;
            physical.Visibility = Visibility.Collapsed;
            wateroverlay.Visibility = Visibility.Collapsed;

            //GoogleViewModel.LoadFromdDatabase(ref googlemap);
            googlemap.SetView(MarkOnMap.Current, MarkOnMap.ZoomLevelCurrent);

            //googlemap.reso
    

            





            

        }
        ~GoogleMaps()
        {
            //GoogleViewModel.SaveIntoDatabase(googlemap);
            //GoogleViewModel.SaveIntoDatabase(googlemap);


        }

        private void ButtonZoomIn_Click(object sender, RoutedEventArgs e)
        {
            googlemap.ZoomLevel++;
        }

        private void ButtonZoomOut_Click(object sender, RoutedEventArgs e)
        {
            googlemap.ZoomLevel--;
        }
    }
}