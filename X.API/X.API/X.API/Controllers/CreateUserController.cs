using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.Service.Commands;

namespace X.API.Controllers
{
    // {"UserName":"vala","Password":"vala","MobileNumber":123123,"EmailAddress":"vala"}
    [ApiController]
    public class CreateUserController : ApiController<CreateUserContainer.CreateUserRequest, CreateUserContainer.CreateUserResponse>
    {
        public CreateUserController(IMediator mediator) : base(mediator) { }
    }
}