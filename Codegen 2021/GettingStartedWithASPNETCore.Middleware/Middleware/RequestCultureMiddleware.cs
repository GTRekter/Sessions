using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GettingStartedWithASPNETCore.Middleware.Middleware
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var cultureQuery = httpContext.Request.Query["culture"];
            if(!string.IsNullOrEmpty(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            await _next(httpContext);
        }
    }
}
