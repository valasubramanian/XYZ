using System;
using X.Domain.Models;

namespace X.Domain.ServiceContracts
{
    public interface IUserAction
    {
        UserAction userAction {get;}
        int PerformAction(UserModel userModel);
    }
}
