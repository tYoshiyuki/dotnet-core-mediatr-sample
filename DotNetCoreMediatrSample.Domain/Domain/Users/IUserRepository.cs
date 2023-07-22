using System.Collections.Generic;

namespace DotNetCoreMediatrSample.Domain.Domain.Users
{
    /// <summary>
    /// <see cref="User"/> のリポジトリインターフェースです。
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// <see cref="User"/> を取得します。
        /// </summary>
        /// <param name="id"><see cref="UserId"/></param>
        /// <returns><see cref="User"/></returns>
        User Find(UserId id);

        /// <summary>
        /// <see cref="User"/> を取得します。
        /// </summary>
        /// <param name="userName"><see cref="UserName"/></param>
        /// <returns><see cref="User"/></returns>
        User Find(UserName userName);

        /// <summary>
        /// <see cref="User"/> を全件取得します。
        /// </summary>
        /// <returns><see cref="User"/>のリスト</returns>
        IEnumerable<User> FindAll();

        /// <summary>
        /// <see cref="User"/> を保存します。
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        void Save(User user);

        /// <summary>
        /// <see cref="User"/> を削除します。
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        void Remove(User user);
    }
}
