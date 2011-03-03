using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.MessageBase;
using System.Runtime.Serialization;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public class LogoutResponse : ResponseBase
    {
        /// <summary>
        /// Default Constructor for LogoutReponse.
        /// </summary>
        public LogoutResponse()
        {

        }
        /// <summary>
        /// Overloaded Constructor for LogoutReponse. 
        /// Sets CorrelationId from incoming Request.
        /// </summary>
        /// <param name="correlationId">The correlation identifier for request and response.</param>
        public LogoutResponse(string correlationId)
            : base(correlationId)
        {
            
        }


        

    }
}
