using System;
using Microsoft.Extensions.DependencyInjection;
using JOIEnergy.Domain.Services;
using JOIEnergy.Domain.Services.SupplierPricePlan;
using JOIEnergy.Domain.Services.SupplierPricePlan.Suppliers;

namespace JOIEnergy.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IMeterReadingService, MeterReadingService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPricePlanService, PricePlanService>();

            services.AddScoped<ISupplier, PowerForEveryoneSupplier>();
            services.AddScoped<ISupplier, TheGreenEcoSupplier>();
            services.AddScoped<ISupplier, DrEvilsDarkEnergySupplier>();
        }
    }
}
