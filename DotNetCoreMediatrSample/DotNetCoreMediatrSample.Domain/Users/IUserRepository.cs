using System.Collections.Generic;

namespace DotNetCoreMediatrSample.Domain.Users
{
    public interface IUserRepository
    {
        User Find(UserId id);
        User Find(UserName userName);
        IEnumerable<User> FindAll();
        void Save(User user);
        void Remove(User user);
    }
}
