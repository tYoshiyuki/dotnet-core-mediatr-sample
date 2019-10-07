using System.Collections.Generic;
using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Domain.Domain.Circles
{
    public interface ICircleNotification
    {
        void Id(CircleId id);
        void Name(string name);
        void Users(List<UserId> users);
    }
}
