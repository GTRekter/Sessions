using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GettingStartedWithASPNETCore.Configuration.Models;

namespace GettingStartedWithASPNETCore.Configuration.Middleware
{
    public class OptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<AppOptions> _injectedOptions;
        public OptionMiddleware(RequestDelegate next, IOptions<AppOptions> injectedOptions)
        {
            _next = next;
            _injectedOptions = injectedOptions;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var id =  _injectedOptions.Value.Id;
            Console.WriteLine($"id: {id}");

            await _next(httpContext);
        }
    }
}
