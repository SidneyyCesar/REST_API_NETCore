
using System.Collections.Generic;
using application.Mapper.Interfaces;
using application.Models.InputModels;
using application.Models.ViewModels;
using domain.Domain.Core;

namespace application.Mapper.Conversors
{
  public class MapperUser : IMapperUser
  {
    IEnumerable<UserViewModel> userViewModelList = new List<UserViewModel>();

    public UserViewModel MapperEntityToViewModel(Users user)
    {
        UserViewModel userModelView = new UserViewModel()
        {
            email = user.email,
            name = user.name
        };

        return userModelView;
    }

    public Users MatterDtoToEntity(UserInputModel userModel)
    {
      var user = new Users()
      {
        id = userModel.id,
        email = userModel.email
      };

      return user;
    }

    public IEnumerable<UserViewModel> MatterListToView(IEnumerable<Users> users)
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