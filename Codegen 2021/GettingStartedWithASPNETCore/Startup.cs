using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWithASPNETCore.Interfaces;
using GettingStartedWithASPNETCore.Middleware;
using GettingStartedWithASPNETCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GettingStartedWithASPNETCore
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Hosting.IHostApplicationLifetime appLifetime)
        {
            // TODO 1: Middleware
            // app.UseMiddleware<RequestCultureMiddleware>();
            // app.UseMiddleware<RequestCultureMiddleware>();
            // app.UseMiddleware<CustomConfigurationMiddleware>();
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync($"Hello {CultureInfo.CurrentCulture.DisplayName}");
            // });

            // TODO 2: Map
            // app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch); // https://localhost:44315?branch=N
            // app.Map("/map1", HandleMapTest1); // https://localhost:44315/map1
            // app.Map("/map2", HandleMapTest2); // https://localhost:44315/map2

            // TODO 3: Host
            // appLifetime.ApplicationStarted.Register(OnStarted);
            // appLifetime.ApplicationStopping.Register(OnStopping);
            // appLifetime.ApplicationStopped.Register(OnStopped);      

            // TODO 4: Transient, Scoped, Singleton
            // Transient objects are always different; a new instance is provided to every controller and every service.
            // Scoped objects are the same within a request, but different across different requests.
            // Singleton objects are the same for every object and every request.
            // Console.WriteLine("First interaction");
            // app.UseMiddleware<SingletonMiddleware>();
            // Console.WriteLine("Second interaction");
            // app.UseMiddleware<SingletonMiddleware>();

            // TODO 5: Configuration files
            // app.Run(async (context) =>
            // {
            //     var starship = new Starship();
            //     _config.GetSection("starship").Bind(starship);
            //     Console.WriteLine($"Starship name: {starship.Name}");

            //     starship = _config.GetSection("starship").Get<Starship>();
            //     Console.WriteLine($"Starship name: {starship.Name}");
            // });
        }

        #region Private methods
        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }
        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }
        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }
        private void OnStarted()
        {
            // Perform post-startup activities here
            Console.Write("Application has started.");
        }
        private void OnStopping()
        {
            // Perform on-stopping activities here
            Console.Write("Application is stopping.");
        }
        private void OnStopped()
        {
            // Perform post-stopped activities here
            Console.Write("Application stopped.");
        }
        #endregion

    }
}
