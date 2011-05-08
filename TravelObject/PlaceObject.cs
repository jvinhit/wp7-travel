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

namespace TravelObject
{
    public abstract class PlaceObject
    {
        public string Name { get; set; }
        public string Article{ get; set; }
        public string IdObject { get; set; }
        public string IdKindPlace { get; set; }
        public GeoCoordinate geoCoor { get; set; }
        public double ZoomLevel { get; set; }
        public Uri Icon { get; set; }
        public string background { get; set; }
    }
}
