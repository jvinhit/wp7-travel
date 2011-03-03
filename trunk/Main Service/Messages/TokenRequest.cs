using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main_Service.MessageBase;
using System.Runtime.Serialization;

namespace Main_Service.Messages
{
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class TokenRequest : RequestBase
    {
       
    }
}
