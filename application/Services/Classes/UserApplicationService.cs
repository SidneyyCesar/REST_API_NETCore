using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using application.Mapper.Interfaces;
using application.Models.InputModels;
using application.Models.ViewModels;
using application.Services.Interfaces;
using domain.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace application.Services.Classes
{
  public class UserApplicationService : IUserApplicationService
  {
    private readonly IUserService userService;
    private readonly IMapperUser userMapper;
    private readonly ILogger<UserApplicationService> logger;
    public UserApplicationService(IUserService userService, IMapperUser userMapper, ILogger<UserApplicationService> logger)
    {
        this.userService = userService;
        this.userMapper = userMapper;    
        this.logger = logger;
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
        try
        {
            this.logger.LogInformation("Listar Usuarios");

            var userList = await userService.GetAll();
            return userMapper.MatterListToView(userList);
        }
        catch(Exception ex)
        {
            this.logger.LogCritical("Falha ao carregar lista de usuários" +  ex.Message);
            return default(IEnumerable<UserViewModel>);
        }
    }
    public async Task<UserViewModel> GetById(int id)
    {
      try
      {
          this.logger.LogInformation("Selecionar Usuario");
                  
          var userView = await userService.GetById(id);
          return userMapper.MapperEntityToViewModel(userView);
      }
      catch(Exception ex)
      {
          this.logger.LogCritical("Falha ao selecionar usuário por id" +  ex.Message);
          return default(UserViewModel);
      }
    }

    public async Task Save(UserInputModel userViewModel)
    {
        try
        {
            this.logger.LogInformation("Selecionar Usuario");
            
            var user = userMapper.MatterInputViewToEntity(userViewModel);
            await userService.Save(user);
        }
        catch(Exception ex)
        {
            this.logger.LogCritical("Falha salvar o usuário" +  ex.Message);
        }
    }
    
    public async Task Remove(int id)
    {
      try
      {
          this.logger.LogInformation("Remover Usuario");
          await userService.Remove(id);
      }
      catch(Exception ex)
      {
          this.logger.LogCritical("Falha deletar o usuário" +  ex.Message);
      }
    }

  }
}