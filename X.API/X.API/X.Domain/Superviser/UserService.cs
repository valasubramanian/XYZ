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
        public UserService(IUserRepositary userRepositary)
        {
            _userRepositary = userRepositary;
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
