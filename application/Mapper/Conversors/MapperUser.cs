using System.Collections.Generic;
using domain.Domain.Entities;
using application.Models.ViewModels;
using application.Models.InputModels;
using application.Mapper.Interfaces.IMapper;

namespace application.Interfaces.Mapper.Conversors
{
  public class MatterUser : IMapperUser
  {
    IEnumerable<UserViewModel> userViewModelList = new List<UserViewModel>();

    public UserViewModel MapperEntityToViewModel(User user)
    {
        UserViewModel userModelView = new UserViewModel()
        {
            email = user.email,
            name = user.name
        };

        return userModelView;
    }

    public User MatterDtoToEntity(UserInputModel userModel)
    {
      User user = new User()
      {
        id = userModel.id,
        email = userModel.email
      };

      return user;
    }

    public IEnumerable<UserViewModel> MatterListToView(IEnumerable<User> users)
    {
      var userListView = new List<UserViewModel>();

      foreach (var u in users)
      {
        userListView.Add(new UserViewModel()
        {
            id = u.id,
            name = u.name
        });
      }

      return userListView;
    }
  }
}