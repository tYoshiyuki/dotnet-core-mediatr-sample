using System;
using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Infrastructure.InMemory.Users
{
    /// <summary>
    /// <see cref="IUserFactory"/> の実装クラスです。
    /// </summary>
    public class UserFactory : IUserFactory
    {
        /// <inheritdoc />
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
