using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.Globalization;

namespace GoogleMapCore
{
    public static class GoogleMapsShared
    {
        private static double Latitude;
        private static double Longitude;
        private static int Zoom;
        private const string URLGoogle = "http://maps.google.com/maps/api/staticmap?center={0},{1}&zoom={2}&size={3}x{4}&maptype=roadmap&{5}&sensor=false";
        private static Size Size;
        private static string getMaker = "markers=color:red|label:0|10.771550,106.698330";

        #region Methods
        //Method Load Maps 1
        public static Bitmap GetMapImage(double lat, double lng, int zoom, Size size)
        {

            Latitude = lat;
            Longitude = lng;
            Zoom = zoom;
            Size = size;
            return (Bitmap)GetMapImage();
        }

        //Method Load Maps 2
        public static Bitmap GetMapImage(double lat, double lng, int zoom, Size size, String maker)
        {
            Latitude = lat;
            Longitude = lng;
            Zoom = zoom;
            Size = size;
            if (maker != null)
                getMaker = maker;
            return (Bitmap)GetMapImage();
        }

        public static Bitmap GetMapImage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(URLGoogle, Latitude.ToString("f6", new CultureInfo("en-US")), Longitude.ToString("f6", new CultureInfo("en-US")), Zoom,Size.Width,Size.Height,getMaker);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }

        ////Method Save Maps To Cache
        //public static Bitmap GetCacheImage(double lat, double lng, int zoom, int size)
        //{
        //   
        //}
        #endregion
    }
}
