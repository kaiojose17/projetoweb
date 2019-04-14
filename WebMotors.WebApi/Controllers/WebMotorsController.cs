using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebMotors.Commom;
using WebMotors.Domain.Entities;
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

        [HttpPost]
        [Route(ApiConstants.Rotas.WebApi.Post)]
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request, [FromBody]AnuncioWebMotors anuncioWebMotors)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                _webMotorsService.Add(anuncioWebMotors);
                return request.CreateResponse(HttpStatusCode.OK, $"Inserido com sucesso!!!");
            });
        }

        [HttpPost]
        [Route(ApiConstants.Rotas.WebApi.Put)]
        public async Task<HttpResponseMessage> Put(HttpRequestMessage request, AnuncioWebMotors anuncioWebMotors)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                _webMotorsService.Update(anuncioWebMotors);
                return request.CreateResponse(HttpStatusCode.OK, $"Atualizado com sucesso!!!");
            });
        }

        [HttpPost]
        [Route(ApiConstants.Rotas.WebApi.Delete)]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, AnuncioWebMotors anuncioWebMotors)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                _webMotorsService.Remove(anuncioWebMotors);
                return request.CreateResponse(HttpStatusCode.OK, $"Deletado com sucesso!!!");
            });
        }

        [HttpPost]
        [Route(ApiConstants.Rotas.WebApi.Recursos.GetbyId)]
        public async Task<HttpResponseMessage> GetbyId(HttpRequestMessage request, int id)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                var anuncio = _webMotorsService.GetById(id);
                return request.CreateResponse(HttpStatusCode.OK, anuncio);
            });
        }


    }
}
