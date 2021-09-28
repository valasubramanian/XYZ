using System;
using System.Linq;
using X.Infrastructure.Context;
using X.Domain.Entities;
using System.Collections.Generic;
using X.Domain.DataContracts;

namespace X.Infrastructure.Adapters
{
    public class UserAdapter : IUserRepositary
    {
        private XDbContext _xdbContext;

        public UserAdapter(XDbContext xdbContext)
        {
            _xdbContext = xdbContext;
        }

        public List<UserEntity> GetAllUsers()
        {
            return _xdbContext.Users.AsQueryable().ToList();
        }

        public UserEntity GetUserById(Guid userId)
        {
            return _xdbContext.Users.FirstOrDefault(w => w.UserId == userId);
        }

        public UserEntity GetUserByEmail(string emailAddress)
        {
            return _xdbContext.Users.FirstOrDefault(w => w.EmailAddress == emailAddress);
        }

        public int CreateUser(UserEntity entity)
        {
            _xdbContext.Users.Add(entity);
            return _xdbContext.SaveChanges();
        }
    }
}
