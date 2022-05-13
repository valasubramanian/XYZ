using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JOIEnergy.Domain.Models;
using JOIEnergy.Domain.Enums;
using JOIEnergy.Domain.Services;
using System.Collections.Generic;

namespace JOIEnergy.Service.PricePlan
{
    public class CalculatedCostRequest : IRequest<CalculatedCostResponse>
    {
        public string SmartMeterId { get; set; }
    }

    public class CalculatedCostResponse : IResponse<Dictionary<string, decimal>>
    {
        public Dictionary<string, decimal> Result { get; set; }
        public string[] Errors { get; set; }
    }

    public class CalculatedCostRequestValidator
    {
        
    }

    public class CalculatedCostHandler : IRequestHandler<CalculatedCostRequest, CalculatedCostResponse>
    {
        private readonly IAccountService _accountService;
        private readonly IPricePlanService _pricePlanService;
        public CalculatedCostHandler(IAccountService accountService, IPricePlanService planService)
        {
            _accountService = accountService;
            _pricePlanService = planService;
        }

        public async Task<CalculatedCostResponse> Handle(CalculatedCostRequest request, CancellationToken token)
        {
            CalculatedCostResponse response = new CalculatedCostResponse();           

            Supplier pricePlanId = _accountService.GetPricePlanIdForSmartMeterId(request.SmartMeterId);
            Dictionary<string, decimal> costPerPricePlan = _pricePlanService.GetConsumptionCostOfElectricityReadingsForEachPricePlan(request.SmartMeterId);
            if (!costPerPricePlan.Any())
                response.Errors = new string[] { string.Format("Smart Meter ID ({0}) not found", request.SmartMeterId) };
            else
                response.Result = costPerPricePlan;
            return response;
        }
    }
}
