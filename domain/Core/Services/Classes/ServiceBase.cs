using System.Collections.Generic;
using System.Threading.Tasks;
using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;
using domain.Interfaces.Repositories;

namespace domain.Services.Classes
{
  public class ServiceBase<T> : IServiceBase<T> where T : class, IEntity
  {
    private readonly IRepositoryBase<T> repository;

    public ServiceBase(IRepositoryBase<T>  repository)
    {
      this.repository = repository;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
      return await repository.GetAll();
    }

    public Task<T> GetById(int id)
    {
      return repository.GetById(id);
    }

    public Task Remove(int id)
    {
      var entity = this.GetById(id).Result;
      return repository.Remove(entity);
    }
    public Task Save(T entity)
    {
      if (entity.id == 0)
        return repository.Add(entity);
      else
        return repository.Update(entity);
    }
  }
}