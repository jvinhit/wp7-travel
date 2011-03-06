using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_Objects;
using System.Drawing;

namespace Data_Objects
{
    public interface IMapImage
    {
        MapImage GetMapImages(double lat, double lng, int zoom,int width, int height);

        MapImage GetMapImages(double lat, double lng, int zoom, int width, int height, String maker);
    }
}
