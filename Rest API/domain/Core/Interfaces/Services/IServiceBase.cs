using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.Core.Interfaces.Services
{
    public interface IServiceBase<T> where T: class
    {         
        Task Add (T entity);
        Task Update(T entity);
        Task Remove (int id);
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
    }
}