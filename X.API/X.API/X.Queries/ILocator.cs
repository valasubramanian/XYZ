using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace X.Infrastructure
{
    public interface ILocator
    {
        Task<TRespone> Get<TRespone>(IRequest<TRespone> reqest, string payload);
    }
}
