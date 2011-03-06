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
        public Business_Objects.MapImage GetMapImages(double lat, double lng, int zoom, int width, int height)
        {
            MapImage mapImage = new MapImage(lat, lng, zoom, width, height);
            Bitmap bitmap = new Bitmap((int)(width), (int)(height));

            bitmap = (Bitmap)GoogleMapCore.GoogleMapsShared.GetMapImage(mapImage.Latitude, mapImage.Longitude, mapImage.Zoom, mapImage.Width,mapImage.Height);
            using (MemoryStream tempStream = new MemoryStream())
            {
                bitmap.Save(tempStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                mapImage.BitmapMapsStream = new byte[tempStream.Length];
                tempStream.Position = 0;
                tempStream.Read(mapImage.BitmapMapsStream, 0, (int)tempStream.Length);
            }

            return mapImage;

        }

        public Business_Objects.MapImage GetMapImages(double lat, double lng, int zoom, int width, int height, string maker)
        {
            MapImage mapImage = new MapImage(lat, lng, zoom, width, height, maker);
            Bitmap bitmap = new Bitmap((int)(width), (int)(height));
            bitmap = (Bitmap)GoogleMapCore.GoogleMapsShared.GetMapImage(mapImage.Latitude, mapImage.Longitude, mapImage.Zoom, mapImage.Width, mapImage.Height, mapImage.GetMaker);

            using (MemoryStream tempStream = new MemoryStream())
            {
                bitmap.Save(tempStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                mapImage.BitmapMapsStream = new byte[tempStream.Length];
                tempStream.Position = 0;
                tempStream.Read(mapImage.BitmapMapsStream, 0, (int)tempStream.Length);
            }
            return mapImage;
        }
    }
}
