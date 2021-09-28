using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using X.Infrastructure.Adapters;
using X.Domain.DataContracts;

namespace X.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        //private Assembly[] Assemblies => 
        public static void AddDataRepositaries(this IServiceCollection services)
        {
            services.AddScoped<IUserRepositary, UserAdapter>();
        }
    }
}
