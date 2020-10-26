using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;

namespace WebApiTemplateCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the app setting json file into configuration object
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();

            // Serilog setting
            Log.Logger = new LoggerConfiguration()
                // read configuration from "appsetting.json"
                .ReadFrom.Configuration(configuration)
                .CreateLogger();


            try
            {
                Log.Information("A P P     S T A R T 1");

                var host = CreateWebHostBuilder(args).Build();

                // Serilog App Start


                //// Get log for app start
                //  var log = host.Services.GetRequiredService<ILogger<Program>>();
                // log.LogInformation("A P P     S T A R T");

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "App failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

            //Add serilog
            .UseSerilog()

                // Configuration for the .net core logger
                //.ConfigureLogging((context, logging) =>
                //{

                //    .net core logger config
                //    logging.ClearProviders();
                //    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                //    logging.AddDebug();
                //    logging.AddConsole();
                //    Default registration.


                //    Custom provider
                //    logging.AddProvider(new LoggerProvider(
                //                              new LoggerConfiguration
                //                              {
                //                                  LogLevel = LogLevel.Error,
                //                                  Color = ConsoleColor.Red
                //                              }));
                //})
                .UseStartup<Startup>();
    }
}
