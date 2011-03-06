using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.DataTranferObjects;
using Business_Objects;

namespace Main_Service.DataMapper
{
    public static class Mapper
    {
        public static MapImageDTO ToObjectDTOTranfer(MapImage mapImage)
        {
            return new MapImageDTO { BitmapMapsStream = mapImage.BitmapMapsStream, 
                                       Latitude = mapImage.Latitude, 
                                       Longitude = mapImage.Longitude, 
                                       GetMaker = mapImage.GetMaker, 
                                       Zoom = mapImage.Zoom, 
                                      Size= mapImage.Size };
        }
    }
}
