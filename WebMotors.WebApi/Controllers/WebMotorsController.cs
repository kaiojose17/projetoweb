using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebMotors.Commom;
using WebMotors.Domain.Interface.Services;
using WebMotors.WebApi.ApiBase;

namespace WebMotors.WebApi.Controllers
{
    [RoutePrefix(ApiConstants.Rotas.WebApi.BaseUri)]
    public class WebMotorsController : ApiBaseController
    {
        public readonly IWebMotorsService _webMotorsService;

        public WebMotorsController(IWebMotorsService webMotorsService)
        {
            _webMotorsService = webMotorsService;
        }

        [HttpGet]
        [Route(ApiConstants.Rotas.WebApi.Get)]
        public async Task<HttpResponseMessage> Get(HttpRequestMessage request)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                var anuncios = _webMotorsService.GetAll();
                return request.CreateResponse(HttpStatusCode.OK, anuncios);
            });
        }
    }
}
