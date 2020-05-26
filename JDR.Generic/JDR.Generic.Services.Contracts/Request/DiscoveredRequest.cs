using JDR.Generic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Services.Contracts.Request
{
    [DataContract]
    public partial class DiscoveredRequest
    {
        [DataMember]
        public BankOperation Operation { get; set; }
    }
}
