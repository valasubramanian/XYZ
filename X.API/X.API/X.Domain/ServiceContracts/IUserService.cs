using System;
using System.Collections.Generic;
using System.Text;
using X.Domain.Models;

namespace X.Domain.ServiceContracts
{
    public interface IUserService
    {
        int PerformAction(UserModel userModel, UserAction userAction);
        List<UserModel> GetAllUsers();
    }
}
