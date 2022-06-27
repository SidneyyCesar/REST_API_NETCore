using domain.Domain.Entities;
using System.Collections.Generic;
using application.Models.ViewModels;
using application.Models.InputModels;

namespace application.Mapper.Interfaces.IMapper
{
    public interface IMapperUser
    {
        User MatterDtoToEntity(UserInputModel userModel);
        IEnumerable<UserViewModel> MatterListToView(IEnumerable<User> users);
        UserViewModel MapperEntityToViewModel(User user);
    }
}