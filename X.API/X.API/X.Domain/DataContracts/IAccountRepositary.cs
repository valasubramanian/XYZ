using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using X.Domain.Entities;

namespace X.Domain.DataContracts
{
    public interface IAccountRepositary
    {
        int CreateUser(UserEntity entity);
        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(Guid userId);
        UserEntity GetUserByEmail(string emailAddress);
    }
}
