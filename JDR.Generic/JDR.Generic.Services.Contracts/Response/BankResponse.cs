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
    public class BankResponse
    {
        [DataMember]
        public List<IAccount> Accounts { get; set; }
    }
}
