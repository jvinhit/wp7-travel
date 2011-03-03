using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

namespace Main_Service.DataTranferObjects
{
    [DataContract(Name = "MapImage", Namespace = "http://www.yourcompany.com/types/")]
    class MapImageDTO
    {
        [DataMember]
        public Bitmap BitmapMaps;

        [DataMember]
        public string GetMaker;

        [DataMember]
        public Size Size;
        [DataMember]
        public double Longitude;
        [DataMember]
        public double Latitude;
        [DataMember]
        public int Zoom;

    }
}
