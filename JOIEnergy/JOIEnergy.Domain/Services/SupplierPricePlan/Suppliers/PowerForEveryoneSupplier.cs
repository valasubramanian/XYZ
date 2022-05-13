using System;
using JOIEnergy.Domain.Enums;

namespace JOIEnergy.Domain.Services.SupplierPricePlan.Suppliers
{
    public class PowerForEveryoneSupplier : SupplierCost, ISupplier
    {
        public Supplier EnergySupplier => Supplier.PowerForEveryone;
        public decimal UnitRate => 1m;
    }
}
