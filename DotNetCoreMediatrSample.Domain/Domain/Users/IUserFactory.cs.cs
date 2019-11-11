namespace DotNetCoreMediatrSample.Domain.Domain.Users
{
    public interface IUserFactory
    {
        User CreateUser(UserName userName, FullName fullName);
    }
}
