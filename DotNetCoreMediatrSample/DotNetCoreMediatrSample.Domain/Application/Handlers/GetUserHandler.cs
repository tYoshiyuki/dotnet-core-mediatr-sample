using System.Threading;
using System.Threading.Tasks;
using DotNetCoreMediatrSample.Domain.Application.Models;
using DotNetCoreMediatrSample.Domain.Application.Queries;
using DotNetCoreMediatrSample.Domain.Domain.Users;
using MediatR;

namespace DotNetCoreMediatrSample.Domain.Application.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IUserRepository _repository;

        public GetUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _repository.Find(new UserId(request.Id));
            var model = user == null ? null : new UserModel(user);
            return Task.FromResult(model);
        }
    }
}
