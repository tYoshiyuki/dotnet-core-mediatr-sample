using DotNetCoreMediatrSample.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreMediatrSample.Domain.Circles
{
    public interface ICircleNotification
    {
        void Id(CircleId id);
        void Name(string name);
        void Users(List<UserId> users);
    }
}
