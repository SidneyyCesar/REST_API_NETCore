using Autofac;
using infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CrossCutting;

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
            builder.RegisterModule(new ContainerRegister());
        }
        
        public void ConfigureServices(IServiceCollection services)
        {   
            var connection = Configuration["connectionString:SqlServer"];

            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connection));
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Documentação", Version = "v1" });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação");
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