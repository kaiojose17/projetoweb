using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Interface;
using WebMotors.Domain.Interface.Services;

namespace WebMotors.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity>
        where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add(TEntity obj)
        {
            return _repository.Add(obj);
        }       

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity Remove(TEntity obj)
        {
            return _repository.Remove(obj);
        }

        public TEntity Update(TEntity obj)
        {
            return _repository.Update(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
