using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Main_Service.MessageBase
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public class RequestBase
    {
        /// <summary>
        /// Each web service request carries a security token as an extra level of security.
        /// Tokens are issued when users are coming online. They can expire if necessary.
        /// Google.com and Amazon.com uses this in their API.
        /// </summary>
        [DataMember]
        public string ClientTag;

        /// <summary>
        /// Each web service request carries a security token as an extra level of security.
        /// Tokens are issued when users are coming online. They can expire if necessary.
        /// Google.com and Amazon.com uses this in their API.
        /// </summary>
        [DataMember]
        public string AccessToken;

        /// <summary>
        /// Minimum version number that client request is required to run under. This facilitates
        /// a certain level of backward compatibility for when the web service API evolves.
        /// Ebay.com uses the version number in their API. 
        /// </summary>
        [DataMember]
        public string Version;

        /// <summary>
        /// A unique number (ideally a Guid) issued by the client representing the instance 
        /// of the request. Avoids rapid-fire processing of the same request over and over 
        /// in denial-of-service type attacks.
        /// </summary>
        [DataMember]
        public string RequestId;


        /// <summary>
        /// Load options indicated what types are to be returned in the request.
        /// </summary>
        [DataMember]
        public string[] LoadOptions;

        /// <summary>
        /// Crud action: Create, Read, Update, Delete
        /// </summary>
        [DataMember]
        public string Action;
    }
}
