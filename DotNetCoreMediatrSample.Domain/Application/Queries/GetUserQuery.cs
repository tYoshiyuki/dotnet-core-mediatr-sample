using DotNetCoreMediatrSample.Domain.Application.Models;
using MediatR;

namespace DotNetCoreMediatrSample.Domain.Application.Queries
{
    /// <summary>
    /// <see cref="UserModel"/> を取得するコマンドです。
    /// </summary>
    public class GetUserQuery : IRequest<UserModel>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">id</param>
        public GetUserQuery(string id)
        {
            Id = id;
        }

        /// <summary>
        /// id
        /// </summary>
        public string Id { get; }
    }
}
