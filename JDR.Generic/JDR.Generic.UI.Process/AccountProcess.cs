using JDR.Generic.Domain;
using JDR.Generic.Services.Contracts.Request;
using JDR.Generic.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.UI.Process
{
    public class AccountProcess : ProcessComponent
    {
        public void Deposit(BankOperation operation)
        {
            var request = new DepositRequest();
            request.Operation = operation;
            var response = HttpPost<DepositRequest>("api/account/deposit", request, MediaType.Json);
        }

        public void Extract(BankOperation operation)
        {
            var request = new ExtractRequest();
            request.Operation = operation;
            var response = HttpPost<ExtractRequest>("api/account/extract", request, MediaType.Json);
        }

        public void Transfer(BankOperation operation)
        {
            var request = new TransferRequest();
            request.Operation = operation;
            var response = HttpPost<TransferRequest>("api/account/transfer", request, MediaType.Json);
        }
    }
}
