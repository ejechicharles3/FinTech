using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("c:\\fintech\\logs\\log-.txt",
                outputTemplate: "{Timespamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj{NewLine}{Exception}}",
                rollingInterval: RollingInterval.Day,
                restrictedToMinimumLevel: LogEventLevel.Information
            ).CreateLogger();
            try
            {
                Log.Information("Application started at " + DateTime.Now);
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, "Application failed");
            }
            finally
            {
                Log.CloseAndFlush(); 
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
