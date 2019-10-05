using DotNetCoreMediatrSample.Domain.Users;
using MediatR;

namespace DotNetCoreMediatrSample.Web.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(UserId id)
        {
            Id = id;
        }

        public UserId Id { get; }
    }
}
