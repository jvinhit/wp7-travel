using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.DataTranferObjects;
using System.Runtime.Serialization;
using Main_Service.MessageBase;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public class MapImageRequest : RequestBase
    {
        [DataMember]
        public MapImageDTO mapImageDTO;
    }
}
