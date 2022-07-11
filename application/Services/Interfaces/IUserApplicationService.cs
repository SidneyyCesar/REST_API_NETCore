using System.Collections.Generic;
using System.Threading.Tasks;
using application.Models.InputModels;
using application.Models.ViewModels;

namespace application.Services.Interfaces
{
    public interface IUserApplicationService
    {
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
        Task Save (UserInputModel userViewModel);
        Task Remove(int id);
    }
}