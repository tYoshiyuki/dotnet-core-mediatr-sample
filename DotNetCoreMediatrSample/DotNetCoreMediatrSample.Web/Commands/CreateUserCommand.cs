using DotNetCoreMediatrSample.Domain.Users;
using MediatR;

namespace DotNetCoreMediatrSample.Web.Commands
{
    public class CreateUserCommand : IRequest
    {
        public CreateUserCommand(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}
