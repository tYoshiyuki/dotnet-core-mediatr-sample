using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreMediatrSample.Domain.Users
{
    public interface IUserFactory
    {
        User CreaUser(UserName userName, FullName fullName);
    }
}
