using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Main_Service.MessageBase
{
    [DataContract(Namespace = "http://www.tannguyen.com/types/")]
    public enum PersistType
    {
        /// <summary>
        /// Insert record in database.
        /// </summary>
        [EnumMember]
        Insert = 1,

        /// <summary>
        /// Update record in database.
        /// </summary>
        [EnumMember]
        Update = 2,

        /// <summary>
        /// Delete record from database.
        /// </summary>
        [EnumMember]
        Delete = 3
    }
}
