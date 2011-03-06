using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.MessageBase;
using System.Runtime.Serialization;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public class LoginResponse : ResponseBase
    {

        /// <summary>
        /// Default Constructor for LoginResponse.
        /// </summary>
        public LoginResponse() { }

        /// <summary>
        /// Overloaded Constructor for LoginResponse. Sets CorrelationId.
        /// </summary>
        /// <param name="correlationId"></param>
        public LoginResponse(string correlationId) : base(correlationId) { }

        /// <summary>
        /// Uri to which client should redirect following successful login. 
        /// This would be necessary if authentication is handled centrally 
        /// and other services are distributed accross multiple servers. 
        /// Not used in this sample application. 
        /// SalesForce.com uses this in their API.
        /// </summary>
        [DataMember]
        public string Uri = "";

        /// <summary>
        /// Session identifier. Useful when sessions are maintained using 
        /// SOAP headers (rather than cookies). Not used in this sample application.
        /// SalesForce.com uses this in their SOAP header model.
        /// </summary>
        [DataMember]
        public string SessionId = "";
    }
}
