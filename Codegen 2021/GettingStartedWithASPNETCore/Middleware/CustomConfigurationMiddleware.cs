using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GettingStartedWithASPNETCore.Models;

namespace GettingStartedWithASPNETCore.Middleware
{
    public class CustomConfigurationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _injectedConfiguration;
        public CustomConfigurationMiddleware(RequestDelegate next, IConfiguration injectedConfiguration)
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
