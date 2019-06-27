using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Neural
{
    /// <summary>
    /// The service that activates Neural's functionality.
    /// </summary>
    public class NeuralMiddleware
    {
        internal static List<Assembly> RegisteredAssemblies { get; } = new List<Assembly>();

        private readonly RequestDelegate next;

        private Type type;

        public NeuralMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //await context.Response.WriteAsync(response);
        }
    }
}