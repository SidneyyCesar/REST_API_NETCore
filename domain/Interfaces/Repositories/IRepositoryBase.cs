using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T: class
    {
        Task Add (T entity);
        Task Update(T entity);
        Task Remove (T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}