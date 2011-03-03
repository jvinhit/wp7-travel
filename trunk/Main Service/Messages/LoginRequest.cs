using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.MessageBase;
using System.Runtime.Serialization;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public class LoginRequest : RequestBase
    {
        /// <summary>
        /// User name credential.
        /// </summary>
        [DataMember]
        public string UserName = "";

        /// <summary>
        /// Password credential.
        /// </summary>
        [DataMember]
        public string Password = "";
    }
}
