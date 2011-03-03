using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Main_Service.MessageBase
{

    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public enum AcknowledgeType
    {
        /// <summary>
        /// Respresents an failed response.
        /// </summary>
        [EnumMember]
        Failure = 0,

        /// <summary>
        /// Represents a successful response.
        /// </summary>
        [EnumMember]
        Success = 1
    }

}
