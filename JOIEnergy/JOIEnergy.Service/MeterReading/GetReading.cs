using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using JOIEnergy.Domain.Models;
using JOIEnergy.Domain.Services;
using System.Collections.Generic;

namespace JOIEnergy.Service.MeterReading
{
    public class GetReadingRequest : IRequest<GetReadingResponse>
    {
        public string SmartMeterId { get; set; }
    }

    public class GetReadingResponse : IResponse<List<ElectricityReading>>
    {
        public List<ElectricityReading> Result { get; set; }
        public string[] Errors { get; set; }
    }

    public class GetReadingRequestValidator
    {
        
    }

    public class GetReadingHandler : IRequestHandler<GetReadingRequest, GetReadingResponse>
    {
        private readonly IMeterReadingService _meterReadingService;
        public GetReadingHandler(IMeterReadingService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        public async Task<GetReadingResponse> Handle(GetReadingRequest request, CancellationToken token)
        {
            GetReadingResponse response = new GetReadingResponse();
            response.Result = _meterReadingService.GetReadings(request.SmartMeterId);
            return response;
        }
    }
}
