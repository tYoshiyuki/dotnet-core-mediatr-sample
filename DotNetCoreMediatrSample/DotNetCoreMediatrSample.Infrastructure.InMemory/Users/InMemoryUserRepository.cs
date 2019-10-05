using DotNetCoreMediatrSample.Domain.Users;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreMediatrSample.Infrastructure.InMemory.Users
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly Dictionary<UserId, User> _store = new Dictionary<UserId, User>();

        public User Find(UserId id)
        {
            return _store.TryGetValue(id, out var target) ? Clone(target) : null;
        }

        public User Find(UserName userName)
        {
            return Find(_store.Values.FirstOrDefault(_ => _.UserName.Equals(userName))?.Id);
        }

        public IEnumerable<User> FindAll()
        {
            return _store.Values.Select(Clone);
        }

        public void Save(User user)
        {
            _store[user.Id] = user;
        }

        public void Remove(User user)
        {
            _store.Remove(user.Id);
        }

        private User Clone(User user)
        {
            return new User(user.Id, user.UserName, user.FullName);
        }
    }
}
