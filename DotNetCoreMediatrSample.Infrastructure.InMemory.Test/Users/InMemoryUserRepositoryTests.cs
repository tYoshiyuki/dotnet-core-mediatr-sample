using System.Collections.Generic;
using System.Linq;
using DotNetCoreMediatrSample.Infrastructure.InMemory.Users;
using Xunit;
using ChainingAssertion;
using DotNetCoreMediatrSample.Domain.Domain.Users;

namespace DotNetCoreMediatrSample.Infrastructure.InMemory.Test.Users
{
    /// <summary>
    /// <see cref="InMemoryUserRepository"/> のテストクラスです。
    /// </summary>
    [Trait("Category", "Logic")]
    public class InMemoryUserRepositoryTests
    {
        private readonly InMemoryUserRepository _userRepository;
        private readonly List<User> _users = new()
        {
            new User(new UserId("1"), new UserName("Taro"), new FullName("Taro", "Yamada")),
            new User(new UserId("2"), new UserName("Jiro"), new FullName("Jiro", "Suzuki")),
            new User(new UserId("3"), new UserName("Saburo"), new FullName("Saburo", "Tanaka"))
        };

        public InMemoryUserRepositoryTests()
        {
            _userRepository = new InMemoryUserRepository();
        }

        private void PrepareUsers()
        {
            foreach (var user in _userRepository.FindAll())
            {
                _userRepository.Remove(user);
            }

            foreach (var user in _users)
            {
                _userRepository.Save(user);
            }
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.Find(UserId)"/> が正常に動作することを確認します。
        /// </summary>
        /// <param name="id"></param>
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("3")]
        public void Find_UserId(string id)
        {
            // Arrange
            PrepareUsers();
            var expect = _users.First(_ => _.UserId.Equals(new UserId(id)));

            // Act
            var result = _userRepository.Find(expect.UserId);

            // Assert
            result.UserId.Is(expect.UserId);
            result.UserName.Is(expect.UserName);
            result.FullName.Is(expect.FullName);
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.Find(UserId)"/> が正常に動作することを確認します。
        /// 該当する <see cref="User"/> が存在しない場合。
        /// </summary>
        [Fact]
        public void Find_UserId_データ無し()
        {
            // Arrange・Act
            var result = _userRepository.Find(new UserId("No User"));

            // Assert
            result.IsNull();
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.Find(UserName)"/> が正常に動作することを確認します。
        /// </summary>
        [Fact]
        public void Find_UserName()
        {
            // Arrange
            PrepareUsers();
            var expect = _users.First(_ => _.UserName.Equals(new UserName("Jiro")));

            // Act
            var result = _userRepository.Find(expect.UserName);

            // Assert
            result.UserId.Is(expect.UserId);
            result.UserName.Is(expect.UserName);
            result.FullName.Is(expect.FullName);
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.Find(UserName)"/> が正常に動作することを確認します。
        /// 該当する <see cref="User"/> が存在しない場合。
        /// </summary>
        [Fact]
        public void Find_UserName_データ無し()
        {
            // Arrange・Act
            var result = _userRepository.Find(new UserName("No User"));

            // Assert
            result.IsNull();
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.FindAll"/> が正常に動作することを確認します。
        /// </summary>
        [Fact]
        public void FindAll()
        {
            // Arrange
            PrepareUsers();
            var expect = _users;

            // Act
            var result = _userRepository.FindAll().ToList();

            // Assert
            result.Count.Is(3);
            foreach (var user in expect)
            {
                var target = result.First(_ => _.UserId.Equals(user.UserId));
                target.UserId.Is(user.UserId);
                target.UserName.Is(user.UserName);
                target.FullName.Is(user.FullName);
            }
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.Save"/> が正常に動作することを確認します。
        /// </summary>
        [Fact]
        public void Save()
        {
            // Arrange
            PrepareUsers();
            var expect = new User(new UserId("4"), new UserName("Shiro"), new FullName("Shiro", "Sato"));

            // Act
            _userRepository.Save(expect);

            // Assert
            var result = _userRepository.Find(expect.UserId);
            result.UserId.Is(expect.UserId);
            result.UserName.Is(expect.UserName);
            result.FullName.Is(expect.FullName);
        }

        /// <summary>
        /// <see cref="InMemoryUserRepository.Remove"/> が正常に動作することを確認します。
        /// </summary>
        /// <param name="user"></param>
        [Theory]
        [MemberData(nameof(TestData))]
        public void RemoveTest(User user)
        {
            // Arrange
            PrepareUsers();
            var expect = user;

            // Act
            _userRepository.Remove(expect);

            // Assert
            _userRepository.Find(expect.UserId).IsNull();
        }

        /// <summary>
        /// テストデータを生成します。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new User(new UserId("1"), new UserName("Taro"), new FullName("Taro", "Yamada")) };
            yield return new object[] { new User(new UserId("2"), new UserName("Jiro"), new FullName("Jiro", "Suzuki")) };
            yield return new object[] { new User(new UserId("3"), new UserName("Saburo"), new FullName("Saburo", "Tanaka"))};
        }
    }
}