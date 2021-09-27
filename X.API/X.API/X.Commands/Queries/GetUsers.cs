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

            public List<User> Result { get; set; }

        }

        public class GetUsersCommandHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
        {
            private XDbContext _db;

            public GetUsersCommandHandler(XDbContext db)
            {
                _db = db;
            }

            public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
            {
                List<User> lstUsers = new List<User>();
                lstUsers.Add(new User() { UserId = Guid.NewGuid(), UserName = "vala", EmailAddress = "vala@gmail.com" });
                lstUsers.Add(new User() { UserId = Guid.NewGuid(), UserName = "reka", EmailAddress = "reka@gmail.com" });
                return new GetUsersResponse() { Result = lstUsers };
                //return new GetUsersResponse() { Result = _db.Users.ToList() };
            }
        }
    }
}
