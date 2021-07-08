using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.Infrastructure;
using X.Service.Commands;

namespace X.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController<TRequest, TResponse> : Controller
        where TRequest : class, IFrameworkRequest<TResponse>
        where TResponse : class, IFrameworkResponse, new()
    {
        private readonly IMediator _mediator;

        public ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<TResponse> Post([FromBody] TRequest request = null)
        {
            return await _mediator.Send(request) as TResponse;
        }
    }
}