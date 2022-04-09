using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using X.Service.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace X.API.Controllers
{
    // {"UserId":1}
    [ApiController]
    [Authorize(Roles = "superadmin, admin")]
    public class GetProductsController : ApiController<GetProductsContainer.GetProductsRequest, GetProductsContainer.GetProductsResponse>
    {
        public GetProductsController(IMediator mediator) : base(mediator) { }
    }
}