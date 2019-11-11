using DotNetCoreMediatrSample.Domain.Application.Models;
using MediatR;

namespace DotNetCoreMediatrSample.Domain.Application.Queries
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public GetUserQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
