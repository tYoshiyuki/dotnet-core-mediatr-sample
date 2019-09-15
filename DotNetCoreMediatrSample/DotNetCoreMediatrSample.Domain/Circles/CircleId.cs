using System;

namespace DotNetCoreMediatrSample.Domain.Circles
{
    public class CircleId : IEquatable<CircleId>
    {
        private string Id { get; }

        public CircleId(string id)
        {
            Id = id;
        } 

        public bool Equals(CircleId other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((CircleId) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}