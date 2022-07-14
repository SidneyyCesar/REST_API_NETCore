using application.Mapper.Conversors;
using application.Mapper.Interfaces;
using application.Services.Classes;
using application.Services.Interfaces;
using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;
using domain.Services.Classes;
using infra.Repository.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting
{
  public static class ContainerRegister
  {
    public static void ConfigureDI(this IServiceCollection builder) 
    {
        builder.AddTransient<IUserApplicationService, UserApplicationService>();
        builder.AddTransient<IUserService, UserService>();
        builder.AddTransient<IUserRepository, UserRepository>();
        builder.AddTransient<IMapperUser, MapperUser>();
    }
  }
}