
// using application.Interfaces.Mapper.Conversors;
// using application.Mapper.Interfaces.IMapper;
// using application.Services.Classes;
// using application.Services.Interfaces;
// using domain.Core.Interfaces.Services;
// using domain.Services;
// using infra.Repository.interfaces;
// using infra.Repository.Persistence;
// using Microsoft.Extensions.DependencyInjection;

// namespace IoC
// {
//     public static class ConfigureDI
//     {
//         public static void LoadDependences(IServiceCollection services)
//         {   
//             services.AddTransient<IUserApplicationService, UserApplicationService>();         
//             // services.AddScoped<IUserService, UserService>();
//             // services.AddScoped<IUserRepository, UserRepository>();
//             services.AddScoped<IMapperUser, MatterUser>();
//         }
//     }
// }