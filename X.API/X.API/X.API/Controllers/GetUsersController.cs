﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.Service.Queries;

namespace X.API.Controllers
{
    // {"UserId":1}
    [ApiController]
    public class GetUsersController : ApiController<GetUsersContainer.GetUsersRequest, GetUsersContainer.GetUsersResponse>
    {
        public GetUsersController(IMediator mediator) : base(mediator) { }
    }
}