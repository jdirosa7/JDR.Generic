using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Domain
{
    public interface IAccount
    {
        int AccountNumber { get; set; }
        float Balance { get; set; }
    }
}
