using System;
using JOIEnergy.Domain.Enums;

namespace JOIEnergy.Domain.Services.SupplierPricePlan.Suppliers
{
    public class TheGreenEcoSupplier : SupplierCost, ISupplier
    {
        public Supplier EnergySupplier => Supplier.TheGreenEco;
        public decimal UnitRate => 2m;
    }
}

