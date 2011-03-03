using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Main_Service.MessageBase;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TokenResponse : ResponseBase
    {
        /// <summary>
        /// Default Constructor for TokenResponse.
        /// </summary>
        public TokenResponse() { }

        /// <summary>
        /// Overloaded Constructor for TokenResponse. Sets CorrelationId.
        /// </summary>
        /// <param name="correlationId"></param>
        public TokenResponse(string correlationId) : base(correlationId) { }

        /// <summary>
        /// Security token returned to the consumer
        /// </summary>
        [DataMember]
        public string AccessToken;
    }
}
