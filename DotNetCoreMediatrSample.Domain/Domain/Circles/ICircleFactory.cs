using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Domain.Domain.Circles
{
    public interface ICircleFactory
    {
        Circle Create(UserId userId, string name);
    }
}
