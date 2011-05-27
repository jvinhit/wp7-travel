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
    public class CafePlace:PlaceObject,IPointObject
    {
        public CafePlace()
            : base()
        {
             this.Icon = new Uri("/Images/ImageForPoint/Coffee.png", UriKind.Relative);
             this.Article = "Cafe";
             background = System.IO.Path.GetFileNameWithoutExtension(this.Icon.ToString());
        }




        public void GetBookings()
        {
            throw new NotImplementedException();
        }
    }
}
