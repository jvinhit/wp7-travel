using System;
using System.Collections.Generic;
using System.Drawing;


namespace GoogleMapCore
{

   public abstract class PureProjection
   {
      public abstract Size TileSize
      {
         get;
      }

      public abstract double Axis
      {
         get;
      }

      public abstract double Flattening
      {
         get;
      }

      public abstract Point FromLatLngToPixel(double lat, double lng, int zoom);

      public abstract PointLatLng FromPixelToLatLng(int x, int y, int zoom);

      public Point FromLatLngToPixel(PointLatLng p, int zoom)
      {
         return FromLatLngToPixel(p.Lat, p.Lng, zoom);
      }

      public PointLatLng FromPixelToLatLng(Point p, int zoom)
      {
         return FromPixelToLatLng(p.X, p.Y, zoom);
      }

      public virtual Point FromPixelToTileXY(Point p)
      {
         return new Point((int) (p.X / TileSize.Width), (int) (p.Y / TileSize.Height));
      }

      public virtual Point FromTileXYToPixel(Point p)
      {
         return new Point((p.X * TileSize.Width), (p.Y * TileSize.Height));
      }

      public abstract Size GetTileMatrixMinXY(int zoom);

      public abstract Size GetTileMatrixMaxXY(int zoom);

      public virtual Size GetTileMatrixSizeXY(int zoom)
      {
         Size sMin = GetTileMatrixMinXY(zoom);
         Size sMax = GetTileMatrixMaxXY(zoom);

         return new Size(sMax.Width - sMin.Width + 1, sMax.Height - sMin.Height + 1);
      }

      public int GetTileMatrixItemCount(int zoom)
      {
         Size s = GetTileMatrixSizeXY(zoom);
         return (s.Width * s.Height);
      }

      public virtual Size GetTileMatrixSizePixel(int zoom)
      {
         Size s = GetTileMatrixSizeXY(zoom);
         return new Size(s.Width * TileSize.Width, s.Height * TileSize.Height);
      }

      public List<Point> GetAreaTileList(RectLatLng rect, int zoom, int padding)
      {
         List<Point> ret = new List<Point>();

         Point topLeft = FromPixelToTileXY(FromLatLngToPixel(rect.LocationTopLeft, zoom));
         Point rightBottom = FromPixelToTileXY(FromLatLngToPixel(rect.LocationRightBottom, zoom));

         for(int x = (topLeft.X - padding); x <= (rightBottom.X + padding); x++)
         {
            for(int y = (topLeft.Y - padding); y <= (rightBottom.Y + padding); y++)
            {
               Point p = new Point(x, y);
               if(!ret.Contains(p) && p.X >= 0 && p.Y >= 0)
               {
                  ret.Add(p);
               }
            }
         }
         ret.TrimExcess();

         return ret;
      }

      public virtual double GetGroundResolution(int zoom, double latitude)
      {
         return (Math.Cos(latitude * (Math.PI / 180)) * 2 * Math.PI * Axis) / GetTileMatrixSizePixel(zoom).Width;
      }

      #region Math Functions
      protected const double PI = Math.PI;
      protected const double HALF_PI = (PI * 0.5);
      protected const double TWO_PI = (PI * 2.0);
      protected const double EPSLoN = 1.0e-10;
      protected const double MAX_VAL = 4;
      protected const double MAXLONG = 2147483647;
      protected const double DBLLONG = 4.61168601e18;
      const double R2D = 180 / Math.PI;
      const double D2R = Math.PI / 180;

      public double DegreesToRadians(double deg)
      {
         return (D2R * deg);
      }

      public double RadiansToDegrees(double rad)
      {
         return (R2D * rad);
      }

      protected static double Sign(double x)
      {
         if(x < 0.0)
            return (-1);
         else
            return (1);
      }

      protected static double AdjustLongitude(double x)
      {
         long count = 0;
         while(true)
         {
            if(Math.Abs(x) <= PI)
               break;
            else
               if(((long) Math.Abs(x / Math.PI)) < 2)
                  x = x - (Sign(x) * TWO_PI);
               else
                  if(((long) Math.Abs(x / TWO_PI)) < MAXLONG)
                  {
                     x = x - (((long) (x / TWO_PI)) * TWO_PI);
                  }
                  else
                     if(((long) Math.Abs(x / (MAXLONG * TWO_PI))) < MAXLONG)
                     {
                        x = x - (((long) (x / (MAXLONG * TWO_PI))) * (TWO_PI * MAXLONG));
                     }
                     else
                        if(((long) Math.Abs(x / (DBLLONG * TWO_PI))) < MAXLONG)
                        {
                           x = x - (((long) (x / (DBLLONG * TWO_PI))) * (TWO_PI * DBLLONG));
                        }
                        else
                           x = x - (Sign(x) * TWO_PI);
            count++;
            if(count > MAX_VAL)
               break;
         }
         return (x);
      }

      protected static void SinCos(double val, out double sin, out double cos)
      {
         sin = Math.Sin(val);
         cos = Math.Cos(val);
      }

      protected static double e0fn(double x)
      {
         return (1.0 - 0.25 * x * (1.0 + x / 16.0 * (3.0 + 1.25 * x)));
      }

      protected static double e1fn(double x)
      {
         return (0.375 * x * (1.0 + 0.25 * x * (1.0 + 0.46875 * x)));
      }

      protected static double e2fn(double x)
      {
         return (0.05859375 * x * x * (1.0 + 0.75 * x));
      }

      protected static double e3fn(double x)
      {
         return (x * x * x * (35.0 / 3072.0));
      }

      protected static double mlfn(double e0, double e1, double e2, double e3, double phi)
      {
         return (e0 * phi - e1 * Math.Sin(2.0 * phi) + e2 * Math.Sin(4.0 * phi) - e3 * Math.Sin(6.0 * phi));
      }

      protected static long GetUTMzone(double lon)
      {
         return ((long) (((lon + 180.0) / 6.0) + 1.0));
      }
      #endregion

      public void FromGeodeticToCartesian(double Lat, double Lng, double Height, out double X, out double Y, out double Z)
      {
         Lat = (Math.PI / 180) * Lat;
         Lng = (Math.PI / 180) * Lng;

         double B = Axis * (1.0 - Flattening);
         double ee = 1.0 - (B / Axis) * (B / Axis);
         double N = (Axis / Math.Sqrt(1.0 - ee * Math.Sin(Lat) * Math.Sin(Lat)));

         X = (N + Height) * Math.Cos(Lat) * Math.Cos(Lng);
         Y = (N + Height) * Math.Cos(Lat) * Math.Sin(Lng);
         Z = (N * (B / Axis) * (B / Axis) + Height) * Math.Sin(Lat);
      }

      public void FromCartesianTGeodetic(double X, double Y, double Z, out double Lat, out double Lng)
      {
         double E = Flattening * (2.0 - Flattening);
         Lng = Math.Atan2(Y, X);

         double P = Math.Sqrt(X * X + Y * Y);
         double Theta = Math.Atan2(Z, (P * (1.0 - Flattening)));
         double st = Math.Sin(Theta);
         double ct = Math.Cos(Theta);
         Lat = Math.Atan2(Z + E / (1.0 - Flattening) * Axis * st * st * st, P - E * Axis * ct * ct * ct);

         Lat /= (Math.PI / 180);
         Lng /= (Math.PI / 180);
      }
   }
}
