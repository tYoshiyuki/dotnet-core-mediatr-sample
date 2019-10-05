using DotNetCoreMediatrSample.Domain.Users;
using DotNetCoreMediatrSample.Web.Commands;
using System.Threading;

namespace DotNetCoreMediatrSample.Web.Handlers
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public void Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _userRepository.Save(request.User);
        }
    }
}
