using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using InfrastructureLayer.Interfaces.BusinessLogic;
using InfrastructureLayer.Interfaces.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
namespace WebApiTemplateCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;

            //// Default registration.
            //loggerFactory.AddProvider(new LoggerProvider(
            //                          new LoggerConfiguration
            //                          {
            //                              LogLevel = LogLevel.Information,
            //                              Color = ConsoleColor.Red
            //                          }));

            //// Custom registration with a configuration object.
            //loggerFactory.AddLogger(c =>
            //{
            //    c.LogLevel = LogLevel.Information;
            //    c.Color = ConsoleColor.Blue;
            //});



        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // App Layers
            services.AddSingleton<IMainBusinessLogic, MainBusinessLogic>();
            services.AddSingleton<IDataAccess, DataAccess>();

            //Business Logic Services
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IPrintService, PrintService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development"); // Json error RFC 7807-compliant payload to the client
                //app.UseDeveloperExceptionPage(); // Developer HTML error page
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseMvc();
           // app.UseFileServer();
        }
    }
}
