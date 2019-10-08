using DotNetCoreMediatrSample.Domain.Application.Commands;
using DotNetCoreMediatrSample.Domain.Application.Exceptions;
using DotNetCoreMediatrSample.Domain.Domain.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace DotNetCoreMediatrSample.Domain.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _repository;
        private readonly UserService _service;
        private readonly IUserFactory _factory;

        public CreateUserHandler(IUserRepository repository, IUserFactory factory)
        {
            _repository = repository;
            _service = new UserService(_repository);
            _factory = factory;
        }

        public Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = new TransactionScope())
            {
                var user = _factory.CreateUser(
                    new UserName(request.UserName),
                    new FullName(request.FirstName, request.FamilyName)
                );

                if (_service.IsDuplicated(user))
                {
                    throw new DomainException("重複しています");
                }

                _repository.Save(user);
                transaction.Complete();
            }
            return Unit.Task;
        }
    }
}
