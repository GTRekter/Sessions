using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWithASPNETCore.Configuration.Models;
using Microsoft.Extensions.Configuration;

namespace GettingStartedWithASPNETCore.Configuration.Middleware
{
    public class ConfigurationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _injectedConfiguration;
        public ConfigurationMiddleware(RequestDelegate next, IConfiguration injectedConfiguration)
        {
            _next = next;
            _injectedConfiguration = injectedConfiguration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var id =  _injectedConfiguration["AppOption:Id"];
            Console.WriteLine($"id: {id}");
            
            await _next(httpContext);
        }
    }
}
