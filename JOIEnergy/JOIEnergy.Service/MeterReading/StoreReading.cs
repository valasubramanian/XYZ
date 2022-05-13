using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JOIEnergy.Domain.Models;
using JOIEnergy.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace JOIEnergy.Service.MeterReading
{
    public class StoreReadingRequest : IRequest<StoreReadingResponse>
    {
        public MeterReadings MeterReadings { get; set; }
    }

    public class StoreReadingResponse : IResponse<bool>
    {
        public bool Result { get; set; }
        public string[] Errors { get; set; }
    }

    public class StoreReadingRequestValidator
    {
        
    }

    public class StoreReadingHandler : IRequestHandler<StoreReadingRequest, StoreReadingResponse>
    {
        private readonly IMeterReadingService _meterReadingService;
        public StoreReadingHandler(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        public async Task<StoreReadingResponse> Handle(StoreReadingRequest request, CancellationToken token)
        {
            if(!IsMeterReadingsValid(request.MeterReadings))
                return new StoreReadingResponse
                {
                    Errors = new string[] { "Invalid Meter Readings" }
                };

            _meterReadingService.StoreReadings(request.MeterReadings.SmartMeterId, request.MeterReadings.ElectricityReadings);

            StoreReadingResponse response = new StoreReadingResponse();
            response.Result = true;
            return response;
        }

        private bool IsMeterReadingsValid(MeterReadings meterReadings)
        {
            String smartMeterId = meterReadings.SmartMeterId;
            List<ElectricityReading> electricityReadings = meterReadings.ElectricityReadings;
            return smartMeterId != null && smartMeterId.Any()
                    && electricityReadings != null && electricityReadings.Any();
        }
    }
}
