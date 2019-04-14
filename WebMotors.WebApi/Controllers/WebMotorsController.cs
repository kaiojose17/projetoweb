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
using WebMotors.Proxy.Interface;
using WebMotors.WebApi.ApiBase;

namespace WebMotors.WebApi.Controllers
{
    [RoutePrefix(ApiConstants.Rotas.WebApi.BaseUri)]
    public class WebMotorsController : ApiBaseController
    {
        public readonly IWebMotorsService _webMotorsService;
        public readonly IAnuncioWebMotorsProxy _anuncioWebMotorsProxy;

        public WebMotorsController(IWebMotorsService webMotorsService, IAnuncioWebMotorsProxy anuncioWebMotorsProxy)
        {
            _webMotorsService = webMotorsService;
            _anuncioWebMotorsProxy = anuncioWebMotorsProxy;
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
                return request.CreateResponse(HttpStatusCode.OK, _webMotorsService.Add(anuncioWebMotors));
            });
        }

        [HttpPost]
        [Route(ApiConstants.Rotas.WebApi.Put)]
        public async Task<HttpResponseMessage> Put(HttpRequestMessage request, AnuncioWebMotors anuncioWebMotors)
        {
            return await GetHttpResponseAsync(request, () =>
            {                
                return request.CreateResponse(HttpStatusCode.OK, _webMotorsService.Update(anuncioWebMotors));
            });
        }

        [HttpPost]
        [Route(ApiConstants.Rotas.WebApi.Delete)]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, AnuncioWebMotors anuncioWebMotors)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                
                return request.CreateResponse(HttpStatusCode.OK, _webMotorsService.Remove(anuncioWebMotors));
            });
        }

        [HttpGet]
        [Route(ApiConstants.Rotas.WebApi.Recursos.GetbyId)]
        public async Task<HttpResponseMessage> GetbyId(HttpRequestMessage request, int id)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                var anuncio = _webMotorsService.GetById(id);
                return request.CreateResponse(HttpStatusCode.OK, anuncio);
            });
        }

        [HttpGet]
        [Route(ApiConstants.Rotas.WebApi.Recursos.Make)]
        public async Task<HttpResponseMessage> GetMake(HttpRequestMessage request)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                var anuncio = _anuncioWebMotorsProxy.GetMakes();
                return request.CreateResponse(HttpStatusCode.OK, anuncio);
            });
        }

        [HttpGet]
        [Route(ApiConstants.Rotas.WebApi.Recursos.Model)]
        public async Task<HttpResponseMessage> GetModel(HttpRequestMessage request, int makeId)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                var anuncio = _anuncioWebMotorsProxy.GetModels(makeId);
                return request.CreateResponse(HttpStatusCode.OK, anuncio);
            });
        }

        [HttpGet]
        [Route(ApiConstants.Rotas.WebApi.Recursos.Version)]
        public async Task<HttpResponseMessage> GetVersion(HttpRequestMessage request, int modelId)
        {
            return await GetHttpResponseAsync(request, () =>
            {
                var anuncio = _anuncioWebMotorsProxy.GetVersions(modelId);
                return request.CreateResponse(HttpStatusCode.OK, anuncio);
            });
        }

    }
}
