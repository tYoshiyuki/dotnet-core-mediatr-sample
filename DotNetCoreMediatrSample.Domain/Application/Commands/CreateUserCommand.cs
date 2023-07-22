using DotNetCoreMediatrSample.Domain.Application.Models;
using MediatR;

namespace DotNetCoreMediatrSample.Domain.Application.Commands
{
    /// <summary>
    /// <see cref="UserModel"/> を作成するコマンドです。
    /// </summary>
    public class CreateUserCommand : IRequest<UserModel>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="firstName">firstName</param>
        /// <param name="familyName">familyName</param>
        public CreateUserCommand(string userName, string firstName, string familyName)
        {
            UserName = userName;
            FirstName = firstName;
            FamilyName = familyName;
        }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// FamilyName
        /// </summary>
        public string FamilyName { get; }
    }
}
