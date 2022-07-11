using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain.Core.Interfaces.Repositories;
using domain.Interfaces.Repositories;
using infra.Data;
using Microsoft.EntityFrameworkCore;

namespace infra.Repository.Persistence
{
  public abstract class RepositoryBase<T>: IRepositoryBase<T> where T: class, IEntity
  {
    private readonly SqlContext sqlContext;

    public RepositoryBase(SqlContext sqlContext)
    {
        this.sqlContext = sqlContext;
    }

    public virtual async Task Add(T entity)
    {
      sqlContext.Set<T>().Add(entity);
      await sqlContext.SaveChangesAsync();
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
      return await sqlContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
      return await sqlContext.Set<T>().Where(x=> x.id == id).FirstAsync();      
    }
    public virtual async Task Save(T entity)
    {
      sqlContext.Set<T>().Remove(entity);
      await sqlContext.SaveChangesAsync();
    }
    public virtual async Task Update(T entity)
    {
      sqlContext.Entry(entity).State = EntityState.Modified;
      await sqlContext.SaveChangesAsync();
    }
    public virtual async Task Remove(T entity)
    {
      sqlContext.Set<T>().Remove(entity);
      await sqlContext.SaveChangesAsync();
    }

  }
}