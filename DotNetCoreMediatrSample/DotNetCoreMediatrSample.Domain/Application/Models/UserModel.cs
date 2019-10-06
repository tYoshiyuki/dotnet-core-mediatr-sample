using DotNetCoreMediatrSample.Domain.Users;

namespace DotNetCoreMediatrSample.Domain.Application.Models
{
    public class UserModel
    {
        public UserModel(User source)
        {
            Id = source.UserId.Id;
            UserName = source.UserName.Name;
            Name = new FullNameModel(source.FullName);
        }

        public string Id { get; }
        public string UserName { get; }
        public FullNameModel Name { get; }

    }
}
