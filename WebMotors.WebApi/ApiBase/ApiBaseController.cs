using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebMotors.WebApi.ApiBase
{
    public class ApiBaseController : ApiController
    {
        protected async Task<HttpResponseMessage> GetHttpResponseAsync(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            return await Task.FromResult(GetHttpResponse(request, codeToExecute));
        }

        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }            
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, new string[] { ex.Message });
            }

            return response;
        }
    }
}