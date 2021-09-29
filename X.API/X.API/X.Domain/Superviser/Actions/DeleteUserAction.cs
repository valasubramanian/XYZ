using System;
using X.Domain.ServiceContracts;
using X.Domain.Models;
using X.Domain.Entities;
using X.Domain.DataContracts;

namespace X.Domain.Superviser.Actions
{
    public class DeleteUserAction : IUserAction
    {
        private IUserRepositary _userRepositary;
        public DeleteUserAction(IUserRepositary userRepositary)
        {
            _userRepositary = userRepositary;
        }

        public UserAction Action => UserAction.Delete;

        public int PerformAction(UserModel userModel)
        {
            UserEntity entity = _userRepositary.GetUserById(userModel.UserId);
            if(entity != null) {
                return 1; // _userRepositary.Update(entity);
            }
            else
                return 0;
        }
    }
}
