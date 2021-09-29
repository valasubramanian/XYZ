using System.Linq;
using System.Collections;
using System;
using System.Collections.Generic;
using X.Domain.ServiceContracts;
using X.Domain.Models;
using X.Domain.Entities;
using X.Domain.DataContracts;

namespace X.Domain.Superviser
{
    public class UserService : IUserService
    {
        private IUserRepositary _userRepositary;
        private IEnumerable<IUserAction> _userActions;

        public UserService(IUserRepositary userRepositary, IEnumerable<IUserAction> userActions)
        {
            _userRepositary = userRepositary;
            _userActions = userActions;
        }

        public int PerformAction(UserModel userModel, UserAction userAction)
        {
            IUserAction action = _userActions.FirstOrDefault(w => w.Action == userAction);
            if(action != null)
                return action.PerformAction(userModel);
            return 0;
        }

        public List<UserModel> GetAllUsers() 
        {
            List<UserModel> lstUsers = new List<UserModel>();
            List<UserEntity> userEntities = _userRepositary.GetAllUsers();
            if(userEntities != null && userEntities.Count > 0) {
                foreach(UserEntity entity in userEntities) {
                    UserModel model = new UserModel();
                    model.UserName = entity.UserName;
                    model.EmailAddress = entity.EmailAddress;
                    lstUsers.Add(model);
                }
            }
            return lstUsers;
        }
    }
}
