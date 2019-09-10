using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreMediatrSample.Domain.Users;

namespace DotNetCoreMediatrSample.Domain.Circles
{
    public interface ICircleFactory
    {
        Circle Create(UserId userId, string name);
    }
}
