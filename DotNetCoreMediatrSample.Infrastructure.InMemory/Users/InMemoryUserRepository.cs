using System.Collections.Generic;
using System.Linq;
using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Infrastructure.InMemory.Users
{
    /// <summary>
    /// <see cref="IUserRepository"/> のインメモリ実装クラスです。
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly Dictionary<UserId, User> Store = new();

        /// <inheritdoc />
        public User Find(UserId id)
        {
            return Store.TryGetValue(id, out var target) ? Clone(target) : null;
        }

        /// <inheritdoc />
        public User Find(UserName userName)
        {
            var target = Store.Values.FirstOrDefault(_ => _.UserName.Equals(userName));
            return target == null ? null : Find(target.UserId);
        }

        /// <inheritdoc />
        public IEnumerable<User> FindAll()
        {
            return Store.Values.Select(Clone);
        }

        /// <inheritdoc />
        public void Save(User user)
        {
            Store[user.UserId] = user;
        }

        /// <inheritdoc />
        public void Remove(User user)
        {
            Store.Remove(user.UserId);
        }

        /// <summary>
        /// <see cref="User"/> を複製します。
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        /// <returns><see cref="User"/></returns>
        private User Clone(User user)
        {
            return new User(user.UserId, user.UserName, user.FullName);
        }
    }
}
