using System.Xml.Linq;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using X.Domain.ServiceContracts;
using X.Domain.Models;
using X.Domain.Entities;
using X.Domain.DataContracts;

namespace X.Domain.Superviser
{
    public class AccountService : IAccountService
    {
        private IAccountRepositary _accountRepositary;
        public AccountService(IAccountRepositary accountRepositary)
        {
            _accountRepositary = accountRepositary;
        }

        public List<UserModel> GetAllUsers() 
        {
            List<UserModel> lstUsers = new List<UserModel>();
            List<UserEntity> userEntities = _accountRepositary.GetAllUsers();
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

        public int CreateUser(UserModel model)
        {
            UserEntity entity = _accountRepositary.GetUserByEmail(model.EmailAddress);
            if(entity == null) {
                entity = new UserEntity();
                entity.UserName = model.UserName;
                entity.EmailAddress = model.EmailAddress;
                return _accountRepositary.CreateUser(entity);
            }
            else
                return -1;
        }
    }
}
