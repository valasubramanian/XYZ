using JOIEnergy.Domain.Enums;

namespace JOIEnergy.Domain.Services
{
    public interface IAccountService
    {
        Supplier GetPricePlanIdForSmartMeterId(string smartMeterId);
    }
}