using System.Collections.Generic;
using System.Threading.Tasks;
using application.Mapper.Interfaces.IMapper;
using application.Models.InputModels;
using application.Models.ViewModels;
using application.Services.Users;
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

    public IEnumerable<UserViewModel> GetAll()
    {
        var userList = userService.GetAll();
        return userMapper.MatterListToView(userList);
    }
    public Task Remove(int id)
    {
      return userService.Remove(id);
    }

    public async Task<UserViewModel> GetById(int id)
    {
      var userView = await userService.GetById(id);
      return userMapper.MapperEntityToViewModel(userView);
    }

    public Task Add(UserInputModel userInput)
    {
      var user = userMapper.MatterDtoToEntity(userInput);
      return userService.Add(user);
    }
  }
}