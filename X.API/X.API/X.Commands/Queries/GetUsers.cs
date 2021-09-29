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
    public class GetUsersContainer
    {
        public class GetUsersRequest : IFrameworkRequest<GetUsersResponse>
        {
            public string UserId { get; set; }
        }

        public class GetUsersResponse : IFrameworkResponse
        {
            public string[] Errors { get; set; }

            public string[] Warnings { get; set; }

            public List<UserModel> Result { get; set; }
        }

        public class GetUsersCommandHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
        {
            private IUserService _userService;
            public GetUsersCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
            {
                // List<UserModel> lstUsers = new List<UserModel>();
                // lstUsers.Add(new UserModel() { UserId = Guid.NewGuid(), UserName = "vala", EmailAddress = "vala@gmail.com" });
                // lstUsers.Add(new UserModel() { UserId = Guid.NewGuid(), UserName = "reka", EmailAddress = "reka@gmail.com" });
                // return new GetUsersResponse() { Result = lstUsers };
                return new GetUsersResponse() { Result = _userService.GetAllUsers() };
            }
        }
    }
}
