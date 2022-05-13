using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Models;
using JOIEnergy.Domain.Services.SupplierPricePlan;

namespace JOIEnergy.Domain.Services
{
    public class PricePlanService : IPricePlanService
    {
        public interface Debug { void Log(string s); };

        private IMeterReadingService _meterReadingService;
        private readonly List<ISupplier> _suppliers;

        public PricePlanService(IMeterReadingService meterReadingService, IEnumerable<ISupplier> suppliers)
        {
            _meterReadingService = meterReadingService;
            _suppliers = suppliers.ToList();
        }

        public Dictionary<String, decimal> GetConsumptionCostOfElectricityReadingsForEachPricePlan(String smartMeterId)
        {
            List<ElectricityReading> electricityReadings = _meterReadingService.GetReadings(smartMeterId);
            if (!electricityReadings.Any())
            {
                return new Dictionary<string, decimal>();
            }
            return _suppliers.ToDictionary(supplier => supplier.EnergySupplier.ToString(), supplier => supplier.CalculateCost(supplier, electricityReadings));
        }
    }
}
