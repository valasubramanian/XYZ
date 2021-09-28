using System;
using System.Collections.Generic;
using System.Text;
using X.Domain.Models;

namespace X.Domain.ServiceContracts
{
    public interface IAccountService
    {
        int CreateUser(UserModel model);
        List<UserModel> GetAllUsers();
    }
}
