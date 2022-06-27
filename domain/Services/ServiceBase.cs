using System.Collections.Generic;
using System.Threading.Tasks;
using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;

namespace domain.Services
{
  public class ServiceBase<T> : IServiceBase<T> where T : class
  {
    private readonly IRepositoryBase<T> repository;

    public ServiceBase(IRepositoryBase<T>  repository)
    {
      this.repository = repository;
    }

    public Task Add(T entity)
    {
      return repository.Add(entity);
    }

    public IEnumerable<T> GetAll()
    {
      return repository.GetAll();
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

    public Task Update(T entity)
    {
      return repository.Update(entity);
    }
  }
}