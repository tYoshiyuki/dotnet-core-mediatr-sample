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
            // TODO テスト実装、NULLで落ちる
            return _store.TryGetValue(id, out var target) ? Clone(target) : null;
        }

        public User Find(UserName userName)
        {
            // TODO テスト実装、NULLで落ちる
            return Find(_store.Values.FirstOrDefault(_ => _.UserName.Equals(userName))?.UserId);
        }

        public IEnumerable<User> FindAll()
        {
            return _store.Values.Select(Clone);
        }

        public void Save(User user)
        {
            _store[user.UserId] = user;
        }

        public void Remove(User user)
        {
            _store.Remove(user.UserId);
        }

        private User Clone(User user)
        {
            return new User(user.UserId, user.UserName, user.FullName);
        }
    }
}
