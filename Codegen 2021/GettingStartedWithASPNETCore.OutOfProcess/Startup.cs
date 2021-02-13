using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStartedWithASPNETCore.OutOfProcess
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async (context) =>
            {
                // Even if AspNetCoreHostingModel is set to OutOfProcess 
                // the default Visual Studio worker process is iisexpress.exe 
                var process = System.Diagnostics.Process.GetCurrentProcess();
                await context.Response.WriteAsync($"worker process: {process.Id} {process.ProcessName}");
            });
        }
    }
}
