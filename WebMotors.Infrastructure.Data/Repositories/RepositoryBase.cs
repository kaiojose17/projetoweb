using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Interface;
using WebMotors.Infrastructure.Data.Context;

namespace WebMotors.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected WebMotorsContext Db = new WebMotorsContext();

        public TEntity Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();

            return obj;
        }        

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity Remove(TEntity obj)
        {
            Db.Entry<TEntity>(obj).State = System.Data.Entity.EntityState.Deleted ;
            Db.SaveChanges();
            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();

            return obj;
        }
    }
}
