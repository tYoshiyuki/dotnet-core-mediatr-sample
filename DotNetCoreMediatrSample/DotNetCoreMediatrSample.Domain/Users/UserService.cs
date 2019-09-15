using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreMediatrSample.Domain.Users
{
    public class UserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public bool IsDuplicated(User user)
        {
            var name = user.UserName;
            var searched = repository.Find(name);

            return searched != null;
        }
    }
}
