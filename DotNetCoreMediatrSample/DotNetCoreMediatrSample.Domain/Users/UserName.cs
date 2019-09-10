namespace DotNetCoreMediatrSample.Domain.Users
{
    public class UserName
    {
        public string Name { get; }

        public UserName(string name)
        {
            Name = name;
        }

        protected bool Equals(UserName other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((UserName)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}