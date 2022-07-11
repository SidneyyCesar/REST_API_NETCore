using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.Core.Interfaces.Services
{
    public interface IServiceBase<T> where T: class
    {         
        Task Save(T entity);
        Task Remove (int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}