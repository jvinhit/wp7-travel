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

namespace TravelObject
{
    public class HotelPlace:PlaceObject,IPointObject
    {
        public HotelPlace()
            : base()
        {
            this.Icon = new Uri("/Images/ImageForPoint/hotel1star.png", UriKind.Relative);
            this.Article = "Hotel";
            background = System.IO.Path.GetFileNameWithoutExtension(this.Icon.ToString());
        }

        public void GetBookings()
        {
            throw new NotImplementedException();
        }
    }
}
