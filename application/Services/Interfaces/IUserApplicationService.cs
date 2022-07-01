using System.Collections.Generic;
using System.Threading.Tasks;
using application.Models.InputModels;
using application.Models.ViewModels;

namespace application.Services.Interfaces
{
    public interface IUserApplicationService
    {
        Task Add(UserInputModel userInput);
        IEnumerable<UserViewModel> GetAll();
        Task<UserViewModel> GetById(int id);
        Task Remove(int id);
        Task Save (UserInputModel userViewModel);
    }
}