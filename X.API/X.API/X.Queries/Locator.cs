using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace X.Infrastructure
{
    public class Locator : ILocator
    {
        private readonly IMediator _mediator;
        public Locator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TRespone> Get<TRespone>(IRequest<TRespone> request, string payload)
        {
            return _mediator.Send(request, default(CancellationToken));
        }
    }
}
