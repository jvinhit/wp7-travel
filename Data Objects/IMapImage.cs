﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_Objects;
using System.Drawing;

namespace Data_Objects
{
    public interface IMapImage
    {
        MapImage GetMapImages(double lat, double lng, int zoom,System.Windows.Size size);

        MapImage GetMapImages(double lat, double lng, int zoom,System.Windows.Size size, String maker);
    }
}