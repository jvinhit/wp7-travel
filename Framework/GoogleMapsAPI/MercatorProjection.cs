using System;
using System.Drawing;

namespace GoogleMaps.Projection
{
   public class MercatorProjection : PureProjection
   {
      const double MinLatitude = -85.05112878;
      const double MaxLatitude = 85.05112878;
      const double MinLongitude = -180;
      const double MaxLongitude = 180;

      Size tileSize = new Size(256, 256);
      public override Size TileSize
      {
         get
         {
            return tileSize;
         }
      }

      public override double Axis
      {
         get
         {
            return 6378137;
         }
      }

      public override double Flattening
      {
         get
         {
            return (1.0 / 298.257223563);
         }
      }

      public override Point FromLatLngToPixel(double lat, double lng, int zoom)
      {
         Point ret = Point.Empty;

         lat = Clip(lat, MinLatitude, MaxLatitude);
         lng = Clip(lng, MinLongitude, MaxLongitude);

         double x = (lng + 180) / 360;
         double sinLatitude = Math.Sin(lat * Math.PI / 180);
         double y = 0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI);

         Size s = GetTileMatrixSizePixel(zoom);
         int mapSizeX = s.Width;
         int mapSizeY = s.Height;

         ret.X = (int) Clip(x * mapSizeX + 0.5, 0, mapSizeX - 1);
         ret.Y = (int) Clip(y * mapSizeY + 0.5, 0, mapSizeY - 1);

         return ret;
      }

      public override PointLatLng FromPixelToLatLng(int x, int y, int zoom)
      {
         PointLatLng ret = PointLatLng.Empty;

         Size s = GetTileMatrixSizePixel(zoom);
         double mapSizeX = s.Width;
         double mapSizeY = s.Height;

         double xx = (Clip(x, 0, mapSizeX - 1) / mapSizeX) - 0.5;
         double yy = 0.5 - (Clip(y, 0, mapSizeY - 1) / mapSizeY);

         ret.Lat = 90 - 360 * Math.Atan(Math.Exp(-yy * 2 * Math.PI)) / Math.PI;
         ret.Lng = 360 * xx;

         return ret;
      }

      double Clip(double n, double minValue, double maxValue)
      {
         return Math.Min(Math.Max(n, minValue), maxValue);
      }

      public override Size GetTileMatrixMinXY(int zoom)
      {
         return new Size(0, 0);
      }

      public override Size GetTileMatrixMaxXY(int zoom)
      {
         int xy = (1 << zoom);
         return new Size(xy - 1, xy - 1);
      }
   }
}
