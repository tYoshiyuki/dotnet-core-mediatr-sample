using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreMediatrSample.Domain.Users;

namespace DotNetCoreMediatrSample.Domain.Circles
{
    public class Circle : IEquatable<Circle>
    {
        public CircleId Id { get; }
        public string CircleName { get; private set; }
        public List<UserId> Users { get; private set; }

        public Circle(CircleId id, string circleName, List<UserId> users)
        {
            Id = id;
            CircleName = circleName;
            Users = users;
        }

        public void Join(User user)
        {
            if (Users.Count >= 30)
            {
                throw new Exception("too many members");
            }
            Users.Add(user.Id);
        }

        // TODO 未実装
        public void Notify(ICircleNotification circleNotification)
        {
            circleNotification.Id(Id);
            circleNotification.Name(CircleName);
            circleNotification.Users(Users);
        }


        public bool Equals(Circle other)
        {
            if (other is null) return false;
            return ReferenceEquals(this, other) || Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Circle) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

    }

}
