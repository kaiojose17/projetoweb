using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain.Interface.Services
{
    public interface IServiceBase<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        TEntity Remove(TEntity obj);
        void Dispose();
    }
}
