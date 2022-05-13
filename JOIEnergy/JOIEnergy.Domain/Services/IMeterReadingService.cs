using System.Collections.Generic;
using JOIEnergy.Domain.Models;

namespace JOIEnergy.Domain.Services
{
    public interface IMeterReadingService
    {
        List<ElectricityReading> GetReadings(string smartMeterId);
        void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings);
    }
}