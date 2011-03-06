﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Main_Service.DataTranferObjects
{
    [DataContract(Name="MapImageDTO",Namespace = "http://www.tannguyen.com/types/")]
    public class MapImageDTO
    {
        [DataMember]
        public MemoryStream BitmapMapsStream;

        [DataMember]
        public string GetMaker;

        [DataMember]
        public System.Windows.Size Size;
        [DataMember]
        public double Longitude;
        [DataMember]
        public double Latitude;
        [DataMember]
        public int Zoom;

    }
}
