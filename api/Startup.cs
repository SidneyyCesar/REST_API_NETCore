using Autofac;
using infra.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.OpenApi.Models;
using CrossCutting;
using Serilog.Context;

namespace api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {   
            var connection = Configuration["connectionString:Database"];

            services.ConfigureDI();

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

            app.UseMiddleware<LogUserNameMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

public class LogUserNameMiddleware
{
    private readonly RequestDelegate next;

    public LogUserNameMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public Task Invoke(HttpContext context)
    {
        Serilog.Context.LogContext.PushProperty("UserName", "context.User.Identity.Name");

        return next(context);
    }
}