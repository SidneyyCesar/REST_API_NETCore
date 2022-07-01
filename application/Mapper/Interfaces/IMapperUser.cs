using System.Collections.Generic;
using application.Models.ViewModels;
using application.Models.InputModels;
using domain.Domain.Core;

namespace application.Mapper.Interfaces
{
    public interface IMapperUser
    {
        Users MatterDtoToEntity(UserInputModel userModel);
        IEnumerable<UserViewModel> MatterListToView(IEnumerable<Users> users);
        UserViewModel MapperEntityToViewModel(Users user);
    }
}