using DotNetCoreMediatrSample.Domain.Users;
using DotNetCoreMediatrSample.Web.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetCoreMediatrSample.Web.Handlers
{
    public class GetUserHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = _userRepository.Find(request.Id);
            return Task.FromResult(result);
        }
    }
}
