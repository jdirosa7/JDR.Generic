using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Domain
{
    public interface IAccount
    {
        int Id { get; set; }
        string AccountNumber { get; set; }
        decimal Balance { get; set; }
    }
}
