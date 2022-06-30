using Autofac;
using infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using application.Services.Classes;
using domain.Services;
using infra.Repository.Persistence;
using application.Mapper.Interfaces.IMapper;
using application.Services.Interfaces;
using domain.Core.Interfaces.Services;
using domain.Core.Interfaces.Repositories;
using application.Interfaces.Mapper.Conversors;

namespace api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureContainer(ContainerBuilder builder) 
        {
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<MapperUser>().As<IMapperUser>();

            
            // builder.RegisterModule(new ModuleIOC());
        }
        
        public void ConfigureServices(IServiceCollection services)
        {   
            var connection = Configuration["connectionString:SqlServer"];

            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Model DDD", Version = "v1" });
            });   
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Model DDD");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}