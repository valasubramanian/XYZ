using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace JOIEnergy.Service
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediatorPattern(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
