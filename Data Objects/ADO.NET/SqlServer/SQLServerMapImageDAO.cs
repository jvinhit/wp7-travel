using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_Objects;
using System.Drawing;
using System.IO;

namespace Data_Objects.ADO.NET.SqlServer
{
    public class SQLServerMapImageDAO : IMapImage
    {
        public Business_Objects.MapImage GetMapImages(double lat, double lng, int zoom, System.Windows.Size size)
        {
            MapImage mapImage = new MapImage(lat, lng, zoom, size);
            Bitmap bitmap = new Bitmap(int.Parse(size.Width.ToString()), int.Parse(size.Height.ToString()));

            bitmap = (Bitmap)GoogleMapCore.GoogleMapsShared.GetMapImage(mapImage.Latitude, mapImage.Longitude, mapImage.Zoom, mapImage.Size);
            bitmap.Save(mapImage.BitmapMapsStream, System.Drawing.Imaging.ImageFormat.Jpeg);


            return mapImage;

        }

        public Business_Objects.MapImage GetMapImages(double lat, double lng, int zoom, System.Windows.Size size, string maker)
        {
            MapImage mapImage = new MapImage(lat, lng, zoom, size, maker);
            Bitmap bitmap = new Bitmap(int.Parse(size.Width.ToString()), int.Parse(size.Height.ToString()));
            bitmap = (Bitmap)GoogleMapCore.GoogleMapsShared.GetMapImage(mapImage.Latitude, mapImage.Longitude, mapImage.Zoom, mapImage.Size, mapImage.GetMaker);
            bitmap.Save(mapImage.BitmapMapsStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return mapImage;
        }
    }
}
