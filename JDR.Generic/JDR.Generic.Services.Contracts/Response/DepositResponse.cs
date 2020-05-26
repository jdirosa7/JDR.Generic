using JDR.Generic.Domain;
using JDR.Generic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Services.Contracts.Response
{
    [DataContract]
    public class DepositResponse
    {
        [DataMember]
        public BankOperation Result { get; set; }
    }
}
