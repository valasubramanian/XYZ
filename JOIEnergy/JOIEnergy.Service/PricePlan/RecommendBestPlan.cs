using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JOIEnergy.Domain.Models;
using JOIEnergy.Domain.Services;
using System.Collections.Generic;

namespace JOIEnergy.Service.PricePlan
{
    public class RecommendBestPlanRequest : IRequest<RecommendBestPlanResponse>
    {
        public string SmartMeterId { get; set; }
        public int? Limit  { get; set; }
    }

    public class RecommendBestPlanResponse : IResponse<Dictionary<string, decimal>>
    {
        public Dictionary<string, decimal> Result { get; set; }
        public string[] Errors { get; set; }
    }

    public class RecommendBestPlanRequestValidator
    {
        
    }

    public class RecommendBestPlanHandler : IRequestHandler<RecommendBestPlanRequest, RecommendBestPlanResponse>
    {
        private readonly IPricePlanService _pricePlanService;
        public RecommendBestPlanHandler(IPricePlanService planService)
        {
            _pricePlanService = planService;
        }

        public async Task<RecommendBestPlanResponse> Handle(RecommendBestPlanRequest request, CancellationToken token)
        {
            RecommendBestPlanResponse response = new RecommendBestPlanResponse();
            
            if (request.SmartMeterId == string.Empty) {
                response.Errors = new string[] { "Smart Meter ID is empty" };
                return response;
            }
            
            var consumptionForPricePlans = _pricePlanService.GetConsumptionCostOfElectricityReadingsForEachPricePlan(request.SmartMeterId);

            if (!consumptionForPricePlans.Any()) {
                response.Errors = new string[] { string.Format("Smart Meter ID ({0}) not found", request.SmartMeterId) };
            }
            else {
                var recommendations = consumptionForPricePlans.OrderBy(pricePlanComparison => pricePlanComparison.Value).ToDictionary(x => x.Key, x => x.Value);
                if (request.Limit.HasValue && request.Limit.Value < recommendations.Count())
                    recommendations = recommendations.Take(request.Limit.Value).ToDictionary(x => x.Key, x => x.Value);
                
                response.Result = recommendations;
            }

            return response;
        }
    }
}
