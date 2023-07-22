using System.Threading;
using System.Threading.Tasks;
using DotNetCoreMediatrSample.Domain.Application.Models;
using DotNetCoreMediatrSample.Domain.Application.Queries;
using DotNetCoreMediatrSample.Domain.Domain.Users;
using MediatR;

namespace DotNetCoreMediatrSample.Domain.Application.Handlers
{
    /// <summary>
    /// <see cref="GetUserQuery"/> を取り扱う <see cref="IRequestHandler{TRequest,TResponse}"/> です。
    /// </summary>
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="repository"><see cref="IUserRepository"/></param>
        public GetUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _repository.Find(new UserId(request.Id));
            var model = user == null ? null : new UserModel(user);
            return Task.FromResult(model);
        }
    }
}
