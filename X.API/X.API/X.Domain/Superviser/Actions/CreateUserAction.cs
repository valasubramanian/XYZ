using System;
using X.Domain.ServiceContracts;
using X.Domain.Models;
using X.Domain.Entities;
using X.Domain.DataContracts;

namespace X.Domain.Superviser.Actions
{
    public class CreateUserAction : IUserAction
    {
        private IUserRepositary _userRepositary;
        public CreateUserAction(IUserRepositary userRepositary)
        {
            _userRepositary = userRepositary;
        }

        public UserAction userAction => UserAction.Create;

        public int PerformAction(UserModel userModel)
        {
            UserEntity entity = _userRepositary.GetUserByEmail(userModel.EmailAddress);
            if(entity == null) {
                entity = new UserEntity();
                entity.UserName = userModel.UserName;
                entity.EmailAddress = userModel.EmailAddress;
                return _userRepositary.CreateUser(entity);
            }
            else
                return -1;
        }
    }
}
