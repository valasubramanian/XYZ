using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using X.Infrastructure;
using X.Infrastructure.Context;
using X.Domain.Models;
using X.Domain.ServiceContracts;

namespace X.Service.Queries
{
    public class GetProductsContainer
    {
        public class GetProductsRequest : IFrameworkRequest<GetProductsResponse>
        {
            public string UserId { get; set; }
        }

        public class GetProductsResponse : IFrameworkResponse
        {
            public string[] Errors { get; set; }

            public string[] Warnings { get; set; }

            public List<ProductModel> Result { get; set; }
        }

        public class GetProductsCommandHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
        {
            private IExternalService _extService;
            public GetProductsCommandHandler(IExternalService extService)
            {
                _extService = extService;
            }

            public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
            {
                List<ProductModel> products = await _extService.GetAllProducts();
                return new GetProductsResponse
                {
                    Result = products
                };
            }
        }
    }
}

