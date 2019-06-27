using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NeuralUnitTesting")]

namespace Neural
{
    /// <summary>
    /// The extensions that allow neural to be used in an application builder.
    /// </summary>
    public static class NeuralMiddlewareExtensions
    {
        /// <summary>
        /// Activates Neural. There is no additional configuration required for this.
        /// </summary>
        /// <param name="builder">The builder of the application.</param>
        public static IApplicationBuilder UseNeural(this IApplicationBuilder builder)
        {
            NeuralMiddleware.RegisteredAssemblies.Add(Assembly.GetExecutingAssembly());
            NeuralMiddleware.RegisteredAssemblies.Add(Assembly.GetAssembly(typeof(NeuralMiddleware)));

            return builder.UseMiddleware<NeuralMiddleware>();
        }

        /// <summary>
        /// Optional configuration to register any assemblies other than the executing assembly.
        /// This allows custom elements and controls to be discovered in external libraries.
        /// </summary>
        /// <param name="builder">The builder of the application.</param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterNeuralAssembly(this IApplicationBuilder builder, Assembly assembly)
        {
            if (NeuralMiddleware.RegisteredAssemblies.Contains(assembly))
            {
                throw new InvalidOperationException("This assembly has already been registered. Each assembly can only be registered once.");
            }

            NeuralMiddleware.RegisteredAssemblies.Add(assembly);
            return builder;
        }
    }
}