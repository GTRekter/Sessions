using GettingStartedWithASPNETCore.DependencyInjection.Interfaces;
using GettingStartedWithASPNETCore.DependencyInjection.Models;
using GettingStartedWithASPNETCore.DependencyInjection.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWithASPNETCore.DependencyInjection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Transient objects are always different; a new instance is provided to every controller and every service.
            // Scoped objects are the same within a request, but different across different requests.
            // Singleton objects are the same for every object and every request.
            services.AddTransient<IOperationTransient, Operation>();
            services.AddTransient<OperationService, OperationService>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
