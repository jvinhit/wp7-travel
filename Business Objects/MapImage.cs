using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Globalization;
using System.Drawing;

namespace Business_Objects
{
    public class MapImage : BusinessObject
    {

        #region 1.Attributes
        private double m_Longitude;
        private double m_Latitude;
        private int m_Zoom;
        private const string URLGoogle = "http://maps.google.com/maps/api/staticmap?center={0},{1}&zoom={2}&size={3}x{3}&maptype=roadmap&{4}&sensor=false";
        private static String GetMaker()
        {
            String maker = "markers=color:red|label:0|10.771550,106.698330";
            return maker;
        }
        #endregion

        #region  2.Properties
        public double Longitude
        {
            get { return m_Longitude; }
            set { m_Longitude = value; }
        }
        public double Latitude
        {
            get { return m_Latitude; }
            set { m_Latitude = value; }
        }
        public int Zoom
        {
            get { return m_Zoom; }
            set { m_Zoom = value; }
        }
        #endregion

        #region 3.Constructor
        public MapImage()
        {
            this.m_Latitude = 0;
            this.m_Longitude = 0;
            this.m_Zoom = 0;
        }
        #endregion

        #region 4.Methods
        //Method Load Maps 1
        public static Bitmap GetMapImage(double lat, double lng, int zoom, int size)
        {
            StringBuilder sb = new StringBuilder();
            String maker = GetMaker();
            sb.AppendFormat(URLGoogle, lat.ToString("f6", new CultureInfo("en-US")), lng.ToString("f6", new CultureInfo("en-US")), zoom, size, maker);
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }

        //Method Load Maps 2
        public static Bitmap GetMapImage(double lat, double lng, int zoom, int size,String maker)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(URLGoogle, lat.ToString("f6", new CultureInfo("en-US")), lng.ToString("f6", new CultureInfo("en-US")), zoom, size, maker);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }

        ////Method Save Maps To Cache
        //public static Bitmap GetCacheImage(double lat, double lng, int zoom, int size)
        //{
        //    return new Bitmap(1,1);
        //}
        #endregion
    }
}
