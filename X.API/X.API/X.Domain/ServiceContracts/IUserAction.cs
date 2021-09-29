using System;
using X.Domain.Models;

namespace X.Domain.ServiceContracts
{
    public interface IUserAction
    {
        UserAction Action {get;}
        int PerformAction(UserModel userModel);
    }
}
