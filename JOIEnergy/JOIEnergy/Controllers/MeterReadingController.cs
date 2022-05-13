using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JOIEnergy.Domain.Models;
using JOIEnergy.Service.MeterReading;
using Microsoft.AspNetCore.Mvc;
using MediatR;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.Controllers
{
    [Route("readings")]
    public class MeterReadingController : Controller
    {
        private readonly IMediator _mediator;

        public MeterReadingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //POST api/values
        [HttpPost("store")]
        public async Task<StoreReadingResponse> Post([FromBody]MeterReadings meterReadings)
        {
            StoreReadingRequest request = new StoreReadingRequest
            {
                MeterReadings = meterReadings
            };
            return await _mediator.Send(request);
        }

        [HttpGet("read/{smartMeterId}")]
        public async Task<GetReadingResponse> GetReading(string smartMeterId) 
        {
            GetReadingRequest request = new GetReadingRequest
            {
                SmartMeterId = smartMeterId
            };
            return await _mediator.Send(request);
        }
    }
}
