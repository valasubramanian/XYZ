using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Models;

namespace JOIEnergy.Domain.Services.SupplierPricePlan
{
    public interface ISupplierCost
    {
        decimal CalculateCost(ISupplier supplier, List<ElectricityReading> electricityReadings);
    }
}
