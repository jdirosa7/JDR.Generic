using JDR.Generic.Domain;
using JDR.Generic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Data
{
    public interface IAccountRepository
    {
        void Deposit(BankOperation operation);
        void Extract(BankOperation operation);
    }
}
