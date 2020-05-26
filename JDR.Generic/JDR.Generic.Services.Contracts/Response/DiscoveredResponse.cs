using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Services.Contracts.Response
{
    [DataContract]
    public class DiscoveredResponse
    {
        [DataMember]
        public BankOperation Result { get; set; }
    }
}
