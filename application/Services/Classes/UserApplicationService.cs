using System.Collections.Generic;
using System.Threading.Tasks;
using application.Mapper.Interfaces;
using application.Models.InputModels;
using application.Models.ViewModels;
using application.Services.Interfaces;
using domain.Core.Interfaces.Services;

namespace application.Services.Classes
{
  public class UserApplicationService : IUserApplicationService
  {
    private readonly IUserService userService;
    private readonly IMapperUser userMapper;

    public UserApplicationService(IUserService userService, IMapperUser userMapper)
    {
        this.userService = userService;
        this.userMapper = userMapper;
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
        var userList = await userService.GetAll();
        return userMapper.MatterListToView(userList);
    }
    public async Task<UserViewModel> GetById(int id)
    {
      var userView = await userService.GetById(id);
      return userMapper.MapperEntityToViewModel(userView);
    }

    public async Task Save(UserInputModel userViewModel)
    {
      var user = userMapper.MatterInputViewToEntity(userViewModel);
      await userService.Save(user);
    }
    
    public Task Remove(int id)
    {
      return userService.Remove(id);
    }

  }
}