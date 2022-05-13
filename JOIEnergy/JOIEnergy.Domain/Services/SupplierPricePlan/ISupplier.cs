using System;
using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Models;

namespace JOIEnergy.Domain.Services.SupplierPricePlan
{
    public interface ISupplier : ISupplierCost
    {
        Supplier EnergySupplier { get; }
        decimal UnitRate { get; }
    }
}
