using application.Mapper.Conversors;
using application.Mapper.Interfaces;
using application.Services.Classes;
using application.Services.Interfaces;
using Autofac;
using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;
using domain.Services;
using domain.Services.Classes;
using infra.Repository.Persistence;

namespace CrossCutting
{
  public class ContainerRegister : Module
  {
    protected override void Load(ContainerBuilder builder) 
    {
        builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
        builder.RegisterType<UserService>().As<IUserService>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
        builder.RegisterType<MapperUser>().As<IMapperUser>();
    }
  }
}