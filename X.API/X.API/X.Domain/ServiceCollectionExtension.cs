using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using X.Domain.ServiceContracts;
using X.Domain.Superviser;
using X.Domain.Superviser.Actions;
using Microsoft.Extensions.DependencyInjection;

namespace X.Domain
{
    public static class ServiceCollectionExtensions
    {
        //private Assembly[] Assemblies => 
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAction, CreateUserAction>();
            services.AddScoped<IUserAction, UpdateUserAction>();
            services.AddScoped<IUserAction, DeleteUserAction>();
            services.AddScoped<IExternalService, ExternalService>();
        }
    }
}
