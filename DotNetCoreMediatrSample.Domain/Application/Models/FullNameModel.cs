using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Domain.Application.Models
{
    public class FullNameModel
    {
        public FullNameModel(FullName source)
        {
            FirstName = source.FirstName;
            FamilyName = source.FamilyName;
        }

        public string FirstName { get; }
        public string FamilyName { get; }
    }
}
