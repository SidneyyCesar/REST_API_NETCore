using application.Interfaces.Mapper.Conversors;
using application.Mapper.Interfaces.IMapper;
using application.Services.Classes;
using application.Services.Users;
using Autofac;
using domain.Core.Interfaces.Repositories;
using domain.Core.Interfaces.Services;
using domain.Services;
using infra.Repository.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.DI
{
    public static class ConfigurationIOC
    {
        public static void Load(IServiceCollection builder)
        {
            builder.AddScoped<IUserApplicationService, UserApplicationService>();
            builder.AddScoped<IUserService, UserService>();
            // builder.AddScoped<IUserRepository, UserRepository>();
            builder.AddScoped<IMapperUser, MatterUser>();
        }

        // public static void Load(ContainerBuilder builder)
        // {
        //     builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
        //     builder.RegisterType<UserService>().As<IUserService>();
        //     builder.RegisterType<UserRepository>().As<IUserRepository>();
        //     builder.RegisterType<IMapperUser>().As<MatterUser>();
        // }
    }
}