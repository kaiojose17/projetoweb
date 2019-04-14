using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebMotors.Commom;
using WebMotors.Proxy.Interface;

namespace WebMotors.Proxy
{
    public class Proxy : IProxy
    {
        private static string _baseAddress;
        private HttpHelper _httpHelper;

        protected HttpHelper HttpHelper
        {
            get
            {
                if (_httpHelper == null)
                {
                    _httpHelper = new HttpHelper(_baseAddress);
                }

                return _httpHelper;
            }
        }

        public Proxy()
        {
            _baseAddress = ConfigurationManager.AppSettings["WebApiAddress"];

            if (string.IsNullOrEmpty(_baseAddress))
                throw new Exception("Erro ao carregar o endereço local");
        }

    }

    public abstract class Proxy<TEntity> : Proxy, IProxy<TEntity>
            where TEntity : class
    {
        public TEntity Add(TEntity obj)
        {
            var uri = ApiConstants.Rotas.WebApi.Post;

            var response = HttpHelper.PostAsync<TEntity>(uri, obj);

            return response;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            var uri = ApiConstants.Rotas.WebApi.Get;

            var response = HttpHelper.GetAsync<TEntity[]>(uri);

            return response;
        }

        public TEntity GetById(int id)
        {
            var uri = string.Format("{0}/{1}", ApiConstants.Rotas.WebApi.Get, id);

            var response = HttpHelper.GetAsync<TEntity>(uri);

            return response;
        }

        public TEntity Remove(TEntity obj)
        {
            var uri = ApiConstants.Rotas.WebApi.Delete;

            var response = HttpHelper.PostAsync<TEntity>(uri, obj);

            return response;
        }

        public TEntity Update(TEntity obj)
        {
            var uri = ApiConstants.Rotas.WebApi.Put;

            var response = HttpHelper.PostAsync<TEntity>(uri, obj);

            return response;
        }
    }
}