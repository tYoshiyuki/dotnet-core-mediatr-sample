using System;

namespace DotNetCoreMediatrSample.Domain.Users
{
    public class FullName : IEquatable<FullName>
    {
        public string FirstName { get; }
        public string FamilyName { get; }

        public FullName(string firstName, string familyName)
        {
            FirstName = firstName;
            FamilyName = familyName;
        }

        public bool Equals(FullName other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName && FamilyName == other.FamilyName;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((FullName)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^ (FamilyName != null ? FamilyName.GetHashCode() : 0);
            }
        }
    }
}