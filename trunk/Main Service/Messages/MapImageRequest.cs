﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.DataTranferObjects;
using System.Runtime.Serialization;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public class MapImageRequest
    {
        [DataMember]
        public MapImageDTO mapImageDTO;
    }
}