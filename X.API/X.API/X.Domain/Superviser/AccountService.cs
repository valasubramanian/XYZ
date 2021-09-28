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
        private IUserRepositary _userRepositary;
        public AccountService(IUserRepositary userRepositary)
        {
            _userRepositary = userRepositary;
        }

        public int CreateUser(UserModel model)
        {
            UserEntity entity = _userRepositary.GetUserByEmail(model.EmailAddress);
            if(entity == null) {
                entity = new UserEntity();
                entity.UserName = model.UserName;
                entity.EmailAddress = model.EmailAddress;
                return _userRepositary.CreateUser(entity);
            }
            else
                return -1;
        }
    }
}
