using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using GettingStartedWithASPNETCore.Interfaces;

namespace GettingStartedWithASPNETCore.Middleware
{
    public class SingletonMiddleware
    {
        private readonly RequestDelegate _next;

        public SingletonMiddleware(RequestDelegate next)
        {
            _next = next;     
        }

        public async Task Invoke(HttpContext httpContext, IOperationTransient transientOperation, IOperationScoped scopedOperation, IOperationSingleton singletonOperation)
        {
            Console.WriteLine($"transientOperation: {transientOperation.OperationId}");
            Console.WriteLine($"scopedOperation: {scopedOperation.OperationId}");
            Console.WriteLine($"singletonOperation: {singletonOperation.OperationId}");

            await _next(httpContext);
        }
    }
}
