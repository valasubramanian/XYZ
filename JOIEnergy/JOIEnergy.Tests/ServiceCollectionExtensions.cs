using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Generator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JOIEnergy.Domain;
using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Models;
using JOIEnergy.Service;

namespace JOIEnergy.Tests
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesForTesting(this IServiceCollection services)
        {
            var readings = GenerateMeterElectricityReadings();
            services.AddDomainServices();
            services.AddMediatorPattern();
            services.AddSingleton((IServiceProvider arg) => readings);
            services.AddSingleton((IServiceProvider arg) => SmartMeterToPricePlanAccounts);
            return services;
        }

        private static Dictionary<string, List<ElectricityReading>> GenerateMeterElectricityReadings() 
        {
            var readings = new Dictionary<string, List<ElectricityReading>>();
            var generator = new ElectricityReadingGenerator();
            var smartMeterIds = SmartMeterToPricePlanAccounts.Select(mtpp => mtpp.Key);

            foreach (var smartMeterId in smartMeterIds)
            {
                readings.Add(smartMeterId, generator.Generate(20));
            }
            return readings;
        }

        public static Dictionary<String, Supplier> SmartMeterToPricePlanAccounts
        {
            get
            {
                Dictionary<String, Supplier> smartMeterToPricePlanAccounts = new Dictionary<string, Supplier>();
                smartMeterToPricePlanAccounts.Add("smart-meter-0", Supplier.DrEvilsDarkEnergy);
                smartMeterToPricePlanAccounts.Add("smart-meter-1", Supplier.TheGreenEco);
                smartMeterToPricePlanAccounts.Add("smart-meter-2", Supplier.DrEvilsDarkEnergy);
                smartMeterToPricePlanAccounts.Add("smart-meter-3", Supplier.PowerForEveryone);
                smartMeterToPricePlanAccounts.Add("smart-meter-4", Supplier.TheGreenEco);
                return smartMeterToPricePlanAccounts;
            }
        }
        
        
    }
}
