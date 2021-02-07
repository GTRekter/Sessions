using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWithASPNETCore.ApplicationLifetime
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            // Perform post-startup activities here
            appLifetime.ApplicationStarted.Register(OnStarted);
            // Perform on-stopping activities here
            appLifetime.ApplicationStopping.Register(OnStopping);
            // Perform post-stopped activities here
            appLifetime.ApplicationStopped.Register(OnStopped);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region Private methods
        private void OnStarted()
        {        
            Console.WriteLine("Application has started.");
        }
        private void OnStopping()
        {        
            Console.WriteLine("Application is stopping.");
        }
        private void OnStopped()
        {      
            Console.WriteLine("Application stopped.");
        }
        #endregion
    }
}
