using DotNetCoreMediatrSample.Domain.Users;
using System;

namespace DotNetCoreMediatrSample.Infrastructure.InMemory.Users
{
    public class UserFactory : IUserFactory
    {
        public User CreateUser(UserName username, FullName fullName)
        {
            return new User(
                new UserId(Guid.NewGuid().ToString()),
                username,
                fullName
            );
        }
    }
}
