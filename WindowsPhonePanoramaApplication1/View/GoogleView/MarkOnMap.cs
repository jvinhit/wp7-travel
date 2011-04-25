using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Device.Location;


namespace WindowsPhonePanoramaApplication1
{
    public static class MarkOnMap
    {
        private static GeoCoordinate _current = new GeoCoordinate();

        public static GeoCoordinate Current
        {
            get 
            {
                //&markers=color:blue|label:|10.75,106.663
                MarkOnMap._current.Latitude = 10.75;
                MarkOnMap._current.Longitude = 106.663;
                return MarkOnMap._current;
            }
        
        }
        private static int _zoomLevelCurrent = 14;

        public static int ZoomLevelCurrent
        {
            get { return MarkOnMap._zoomLevelCurrent; }
            set { MarkOnMap._zoomLevelCurrent = value; }
        }


    }
}
