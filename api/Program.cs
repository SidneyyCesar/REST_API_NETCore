using System.Collections.ObjectModel;
using System.Data;
using api;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace RestApiModeloDDD.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            // var connectionStringLog = configuration["connectionString:Log"];
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
            .CreateLogger();
                        
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()      
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
