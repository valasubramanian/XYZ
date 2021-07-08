using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace X.Infrastructure
{
    public interface IFrameworkRequest<TResponse> : IRequest<TResponse>
    {
    }
}
