using JDR.Generic.Business;
using JDR.Generic.Services.Contracts.Request;
using JDR.Generic.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace JDR.Generic.Services.Http
{
    [RoutePrefix("api/account")]
    public class AccountServiceHttp : ApiController
    {
        [HttpPost]
        [Route("deposit")]
        public DepositResponse deposit(DepositRequest request)
        {
            try
            {
                var req = request.Operation.TargetAccount.GetType().Name;

                AccountContext context;

                if (req == "SavingAccount")
                    context = new AccountContext(new SavingAccountComponent());
                else
                    context = new AccountContext(new CurrentAccountComponent());

                var response = new DepositResponse();
                //var bc = new SavingAccountComponent();
                //bc.Deposit(request.Operation);

                context.Deposit(request.Operation);

                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("extract")]
        public ExtractResponse extract(ExtractRequest request)
        {
            try
            {
                var response = new ExtractResponse();
                var bc = new SavingAccountComponent();
                bc.Extract(request.Operation);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("transfer")]
        public TransferResponse transfer(TransferRequest request)
        {
            try
            {
                var response = new TransferResponse();
                var bc = new SavingAccountComponent();
                bc.Transfer(request.Operation);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}
