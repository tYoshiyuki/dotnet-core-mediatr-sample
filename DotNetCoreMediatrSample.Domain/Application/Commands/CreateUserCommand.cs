using DotNetCoreMediatrSample.Domain.Application.Models;
using MediatR;

namespace DotNetCoreMediatrSample.Domain.Application.Commands
{
    public class CreateUserCommand : IRequest<UserModel>
    {
        public CreateUserCommand(string userName, string firstName, string familyName)
        {
            UserName = userName;
            FirstName = firstName;
            FamilyName = familyName;
        }

        public string UserName { get; }
        public string FirstName { get; }
        public string FamilyName { get; }
    }
}
