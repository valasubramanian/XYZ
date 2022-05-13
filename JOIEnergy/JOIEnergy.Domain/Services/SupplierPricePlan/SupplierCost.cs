using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Domain.Models;

namespace JOIEnergy.Domain.Services.SupplierPricePlan
{
    public abstract class SupplierCost : ISupplierCost
    {
        public virtual decimal CalculateCost(ISupplier supplier, List<ElectricityReading> electricityReadings)
        {
            var average = CalculateAverageReading(electricityReadings);
            var timeElapsed = CalculateTimeElapsed(electricityReadings);
            var averagedCost = average / timeElapsed;
            return averagedCost * supplier.UnitRate;
        }

        private decimal CalculateAverageReading(List<ElectricityReading> electricityReadings)
        {
            var newSummedReadings = electricityReadings.Select(readings => readings.Reading).Aggregate((reading, accumulator) => reading + accumulator);
            return newSummedReadings / electricityReadings.Count();
        }

        private decimal CalculateTimeElapsed(List<ElectricityReading> electricityReadings)
        {
            var first = electricityReadings.Min(reading => reading.Time);
            var last = electricityReadings.Max(reading => reading.Time);
            return (decimal)(last - first).TotalHours;
        }
    }
}
