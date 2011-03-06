using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Globalization;
using System.Drawing;
using Business_Objects.Business_Rules;
using System.IO;

namespace Business_Objects
{
    public class MapImage : BusinessObject
    {

        #region 1.Attributes
        private double m_Longitude;
        private double m_Latitude;
        private int m_Zoom;

        private System.Windows.Size m_Size;
        private string getMaker = "markers=color:red|label:0|10.771550,106.698330";
        private MemoryStream m_bitmapMapsStream;


        #endregion

        #region  2.Properties
        //private static String GetMaker()
        //{
        //    String maker = ;
        //    return maker;
        //}
        public MemoryStream BitmapMapsStream
        {
            get { return m_bitmapMapsStream; }
            set { m_bitmapMapsStream = value; }
        }


        public string GetMaker
        {
            get { return getMaker; }
            set { getMaker = value; }
        }

        public System.Windows.Size Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }
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
            AddRule(new ValidateRange("Latitude", -90, 90, ValidationDataType.Double));
            AddRule(new ValidateRange("Longitude", -180, 180, ValidationDataType.Double));
            AddRule(new ValidateRange("Zoom", 0, 21, ValidationDataType.Integer));

            this.m_Latitude = 40.714728;
            this.m_Longitude = -73.998672;
            this.m_Zoom = 0;
            this.Size = new System.Windows.Size(480, 800);
            //this.BitmapMaps = new Bitmap(this.Size.Width, this.Size.Height);
            this.BitmapMapsStream = new MemoryStream();
        }
        public MapImage(double lat, double lng, int zoom,System.Windows.Size size)
        {
            this.Latitude = lat;
            this.Longitude = lng;
            this.Zoom = zoom;
            this.Size = size;
            //this.BitmapMaps = new Bitmap(this.Size.Width, this.Size.Height);
            this.BitmapMapsStream = new MemoryStream();
        }
        public MapImage(double lat, double lng, int zoom,System.Windows.Size size, String maker)
            : this(lat, lng, zoom, size)
        {

            if (maker != null)
                this.getMaker = maker;

        }
        #endregion

    }
}
