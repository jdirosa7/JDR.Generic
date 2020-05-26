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
    [RoutePrefix("api/bank")]
    public class BankServiceHttp : ApiController
    {
        [HttpGet]
        [Route("getAccounts")]
        public BankResponse getAccounts(BankRequest request)
        {
            try
            {
                var response = new BankResponse();
                var bc = new BankComponent();
                response.Accounts = bc.GetAccounts();
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
