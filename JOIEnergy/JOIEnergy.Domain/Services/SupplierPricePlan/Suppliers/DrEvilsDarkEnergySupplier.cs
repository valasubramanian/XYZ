using System;
using JOIEnergy.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Models;

namespace JOIEnergy.Domain.Services.SupplierPricePlan.Suppliers
{
    public class DrEvilsDarkEnergySupplier : SupplierCost, ISupplier
    {
        public Supplier EnergySupplier => Supplier.DrEvilsDarkEnergy;
        public decimal UnitRate => 10m;

        public override decimal CalculateCost(ISupplier supplier, List<ElectricityReading> electricityReadings)
        {
            decimal cost = base.CalculateCost(supplier, electricityReadings);
            return cost * 2;
        }
    }
}

