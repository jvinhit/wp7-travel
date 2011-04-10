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

namespace WindowsPhonePanoramaApplication1.Views.GoogleMaps
{
    public partial class GoogleMaps : PhoneApplicationPage
    {
        private static bool bufferClick = false;
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


            googlemap.SetView(MarkOnMap.Current, MarkOnMap.ZoomLevelCurrent);

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