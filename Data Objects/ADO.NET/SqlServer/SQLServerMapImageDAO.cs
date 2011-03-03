using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_Objects;
using System.Drawing;

namespace Data_Objects.ADO.NET.SqlServer
{
    class SQLServerMapImageDAO : IMapImage
    {
        public Business_Objects.MapImage GetMapImages(double lat, double lng, int zoom, System.Drawing.Size size)
        {
            MapImage mapImage = new MapImage(lat, lng, zoom, size);
            mapImage.BitmapMaps = (Bitmap)GoogleMapCore.GoogleMapsShared.GetMapImage(mapImage.Latitude, mapImage.Longitude, mapImage.Zoom, mapImage.Size);


            return mapImage;


        }

        public Business_Objects.MapImage GetMapImages(double lat, double lng, int zoom, System.Drawing.Size size, string maker)
        {
            MapImage mapImage = new MapImage(lat, lng, zoom, size, maker);
            mapImage.BitmapMaps = (Bitmap)GoogleMapCore.GoogleMapsShared.GetMapImage(mapImage.Latitude, mapImage.Longitude, mapImage.Zoom, mapImage.Size, mapImage.GetMaker);


            return mapImage;
        }
    }
}
