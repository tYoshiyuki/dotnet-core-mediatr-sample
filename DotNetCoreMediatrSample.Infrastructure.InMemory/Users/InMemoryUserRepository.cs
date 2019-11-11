using System.Collections.Generic;
using System.Linq;
using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Infrastructure.InMemory.Users
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly Dictionary<UserId, User> Store = new Dictionary<UserId, User>();

        public User Find(UserId id)
        {
            return Store.TryGetValue(id, out var target) ? Clone(target) : null;
        }

        public User Find(UserName userName)
        {
            var target = Store.Values.FirstOrDefault(_ => _.UserName.Equals(userName));
            return target == null ? null : Find(target.UserId);
        }

        public IEnumerable<User> FindAll()
        {
            return Store.Values.Select(Clone);
        }

        public void Save(User user)
        {
            Store[user.UserId] = user;
        }

        public void Remove(User user)
        {
            Store.Remove(user.UserId);
        }

        private User Clone(User user)
        {
            return new User(user.UserId, user.UserName, user.FullName);
        }
    }
}
