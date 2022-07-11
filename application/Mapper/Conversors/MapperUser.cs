
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

    public Users MatterInputViewToEntity(UserInputModel userModel)
    {
      var user = new Users()
      {
        id = userModel.id,
        name = userModel.name,
        email = userModel.email,
        password = userModel.password,
        status = userModel.status
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
            name = u.name,
            email = u.email,
            status = u.status
        });
      }

      return userListView;
    }
  }
}