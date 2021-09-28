using System;
using System.Collections.Generic;
using System.Text;
using X.Domain.Models;

namespace X.Domain.ServiceContracts
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
    }
}
