using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using X.Infrastructure;
using X.Domain;
using X.Domain.ServiceContracts;
using X.Domain.Models;

namespace X.Service.Commands
{
    public class CreateUserContainer
    {
        public class CreateUserRequest : IFrameworkRequest<CreateUserResponse>
        {
            public string UserName { get; set; }

            public string Password { get; set; }

            public int MobileNumber { get; set; }

            public string EmailAddress { get; set; }
        }

        public class CreateUserResponse : IFrameworkResponse
        {
            public string[] Errors { get; set; }

            public string[] Warnings { get; set; }

            public object Result { get; set; }

        }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
        {
            private IUserService _userService;
            public CreateUserCommandHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
            {
                UserModel model = new UserModel() {
                    UserName = request.UserName,
                    EmailAddress = request.EmailAddress
                };

                return new CreateUserResponse() { Result = _userService.PerformAction(model, UserAction.Create) };
            }
        }
    }
}
