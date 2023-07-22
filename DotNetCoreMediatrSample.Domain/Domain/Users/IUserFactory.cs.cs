namespace DotNetCoreMediatrSample.Domain.Domain.Users
{
    /// <summary>
    /// <see cref="User"/> のファクトリインターフェースです。
    /// </summary>
    public interface IUserFactory
    {
        /// <summary>
        /// <see cref="User"/> を生成します。
        /// </summary>
        /// <param name="userName"><see cref="UserName"/></param>
        /// <param name="fullName"><see cref="FullName"/></param>
        /// <returns><see cref="User"/></returns>
        User CreateUser(UserName userName, FullName fullName);
    }
}
