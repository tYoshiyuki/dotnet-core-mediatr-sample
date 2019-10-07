using System;

namespace DotNetCoreMediatrSample.Domain.Domain.Users
{
    public class UserId : IEquatable<UserId>
    {
        public string Id { get; }

        public UserId(string id)
        {
            Id = id;
        }

        public bool Equals(UserId other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserId)obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}