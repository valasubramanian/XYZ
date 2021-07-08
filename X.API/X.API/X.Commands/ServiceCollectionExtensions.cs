using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;

namespace X.Service
{
    public static class ServiceCollectionExtensions
    {
        //private Assembly[] Assemblies => 
        public static void AddLocator(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();
            services.AddMediatR(asm);
        }
    }
}
