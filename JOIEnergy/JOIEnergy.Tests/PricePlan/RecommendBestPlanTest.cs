using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using JOIEnergy.Domain.Services;
using JOIEnergy.Domain.Models;
using JOIEnergy.Service.PricePlan;
using Microsoft.Extensions.DependencyInjection;

namespace JOIEnergy.Tests.PricePlan
{
    public class RecommendBestPlanTest  : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;
        public RecommendBestPlanTest()
        {
            _serviceProvider = new ServiceCollection()
                                    .AddServicesForTesting()
                                    .BuildServiceProvider();
        }

        [Fact]
        public void RecommendBestPlan_ShouldReturnError_WhenSmartMeterIdEmpty()
        {
            var planService = _serviceProvider.GetService<IPricePlanService>();
            
            RecommendBestPlanRequest request = new RecommendBestPlanRequest
            {
                SmartMeterId = string.Empty,
                Limit = 1
            };

            RecommendBestPlanHandler handler = new RecommendBestPlanHandler(planService);
            Task<RecommendBestPlanResponse> response = handler.Handle(request, new CancellationToken());

            Assert.NotNull(response.Result);
            Assert.Null(response.Result.Result);
            Assert.NotNull(response.Result.Errors);
            Assert.Equal(1, response.Result.Errors.Length);
            Assert.Equal("Smart Meter ID is empty", response.Result.Errors[0]);
        }

        [Fact]
        public void RecommendBestPlan_ShouldReturnError_WhenInvalidSmartMeterIdProvided()
        {
            var planService = _serviceProvider.GetService<IPricePlanService>();
            
            RecommendBestPlanRequest request = new RecommendBestPlanRequest
            {
                SmartMeterId = "smart-meter-invalid",
                Limit = 1
            };

            RecommendBestPlanHandler handler = new RecommendBestPlanHandler(planService);
            Task<RecommendBestPlanResponse> response = handler.Handle(request, new CancellationToken());

            Assert.NotNull(response.Result);
            Assert.Null(response.Result.Result);
            Assert.NotNull(response.Result.Errors);
            Assert.Equal(1, response.Result.Errors.Length);
            Assert.Equal("Smart Meter ID (smart-meter-invalid) not found", response.Result.Errors[0]);
        }

        [Fact]
        public void RecommendBestPlan_ShouldReturnResponse_WhenValidSmartMeterIdProvided()
        {
            var planService = _serviceProvider.GetService<IPricePlanService>();
            
            RecommendBestPlanRequest request = new RecommendBestPlanRequest
            {
                SmartMeterId = "smart-meter-0",
                Limit = 1
            };

            RecommendBestPlanHandler handler = new RecommendBestPlanHandler(planService);
            Task<RecommendBestPlanResponse> response = handler.Handle(request, new CancellationToken());

            Assert.NotNull(response.Result);
            Assert.Null(response.Result.Errors);
            Assert.NotNull(response.Result.Result);
        }


        public void Dispose()
        {
            
        }
    }
}
