using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Proxy.Interface
{
    public interface IProxy { }

    public interface IProxy<TEntity> : IProxy
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        TEntity Remove(TEntity obj);
    }
}
