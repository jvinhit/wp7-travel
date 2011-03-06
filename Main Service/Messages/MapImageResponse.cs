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
    public class MapImageResponse : ResponseBase
    {
        [DataMember]
        public MapImageDTO mapImageDTO;
        /// <summary>
        /// Default Constructor for MapImageResponse.
        /// </summary>
        public MapImageResponse()
        {
            mapImageDTO = new MapImageDTO();
        }
        /// <summary>
        /// Overloaded Constructor for MapImageResponse. 
        /// Sets CorrelationId from incoming Request.
        /// </summary>
        /// <param name="correlationId">The correlation identifier for request and response.</param>
        public MapImageResponse(string correlationId)
            : base(correlationId)
        {
            mapImageDTO = new MapImageDTO();
        }
                                       
      
                                       
    }
}
