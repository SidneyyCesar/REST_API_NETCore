using domain.Domain.Entities;
using System.Collections.Generic;
using application.Models.ViewModels;
using application.Models.InputModels;

namespace application.Mapper.Interfaces.IMapper
{
    public interface IMapperUser
    {
        Users MatterDtoToEntity(UserInputModel userModel);
        IEnumerable<UserViewModel> MatterListToView(IEnumerable<Users> users);
        UserViewModel MapperEntityToViewModel(Users user);
    }
}