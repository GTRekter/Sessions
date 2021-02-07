using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GettingStartedWithASPNETCore.Configuration.Models;

namespace GettingStartedWithASPNETCore.Configuration
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
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run((context) => {
                var starship = new Starship();
                _config.GetSection("starship").Bind(starship);
                Console.WriteLine($"Starship name: {starship.Name}");

                starship = _config.GetSection("starship").Get<Starship>();
                Console.WriteLine($"Starship name: {starship.Name}");

                return System.Threading.Tasks.Task.CompletedTask;
            });
        }
    }
}
