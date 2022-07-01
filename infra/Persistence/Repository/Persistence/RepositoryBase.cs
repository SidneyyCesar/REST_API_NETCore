using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Core.Interfaces.Repositories;
using infra.Data;
using Microsoft.EntityFrameworkCore;

namespace infra.Repository.Persistence
{
  public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

    public virtual async Task Add(T entity)
    {
      try
      {
        sqlContext.Set<T>().Add(entity);
        await sqlContext.SaveChangesAsync();
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public virtual IEnumerable<T> GetAll()
    {
      try
      {
        return sqlContext.Set<T>().ToList();
      }
      catch (System.Exception)
      {        
        throw;
      }
    }

    public virtual Task<T> GetById(int id)
    {
      throw new System.NotImplementedException();
    }

    public virtual async Task Remove(T entity)
    {
      try
      {
        sqlContext.Set<T>().Remove(entity);
        await sqlContext.SaveChangesAsync();
      }
      catch (System.Exception)
      {        
        throw;
      }
    }

    public virtual async Task Update(T entity)
    {
      try
      {
        sqlContext.Entry(entity).State = EntityState.Modified;
        await sqlContext.SaveChangesAsync();
      }
      catch (System.Exception)
      {        
        throw;
      }
    }
  }
}