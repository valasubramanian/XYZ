using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOIEnergy.Domain.Models;
using JOIEnergy.Service.PricePlan;
using Microsoft.AspNetCore.Mvc;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.Controllers
{
    [Route("price-plans")]
    public class PricePlanComparatorController : Controller
    {
        private readonly IMediator _mediator;

        public PricePlanComparatorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("compare-all/{smartMeterId}")]
        public async Task<CalculatedCostResponse> CalculatedCostForEachPricePlan(string smartMeterId)
        {
            CalculatedCostRequest request = new CalculatedCostRequest
            {
                SmartMeterId = smartMeterId
            };
            return await _mediator.Send(request);
        }

        [HttpGet("recommend/{smartMeterId}")]
        public async Task<RecommendBestPlanResponse> RecommendCheapestPricePlans(string smartMeterId, int? limit = null) 
        {
            RecommendBestPlanRequest request = new RecommendBestPlanRequest
            {
                SmartMeterId = smartMeterId,
                Limit = limit
            };
            return await _mediator.Send(request);
        }
    }
}
