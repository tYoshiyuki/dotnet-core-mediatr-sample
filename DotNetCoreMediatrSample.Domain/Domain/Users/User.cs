using System;
using DotNetCoreMediatrSample.Domain.Domain.Circles;

namespace DotNetCoreMediatrSample.Domain.Domain.Users
{
    public class User : IEquatable<User>
    {
        public UserId UserId { get; }
        public UserName UserName { get; private set; }
        public FullName FullName { get; private set; }

        public User(UserId userId, UserName userName, FullName fullName)
        {
            UserId = userId;
            UserName = userName;
            FullName = fullName;
        }

        public bool Equals(User other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || Equals(UserId, other.UserId);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return (UserId != null ? UserId.GetHashCode() : 0);
        }

        public void ChangeUserName(UserName userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }

        public void ChangeFullName(FullName fullName)
        {
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        }

        public Circle CreateCircle(ICircleFactory circleFactory, string circleName)
        {
            return circleFactory.Create(UserId, circleName);
        }
    }
}
