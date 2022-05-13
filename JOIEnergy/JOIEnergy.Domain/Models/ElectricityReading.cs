using System;

namespace JOIEnergy.Domain.Models
{
    public class ElectricityReading
    {
        public DateTime Time { get; set; }
        public Decimal Reading { get; set; }
    }
}
