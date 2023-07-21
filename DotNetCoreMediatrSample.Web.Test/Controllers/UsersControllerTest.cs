using System;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DotNetCoreMediatrSample.Web.Controllers;
using DotNetCoreMediatrSample.Web.ViewModel;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DotNetCoreMediatrSample.Web.Test.Controllers
{
    /// <summary>
    /// <see cref="UsersController"/> のテストクラスです。
    /// </summary>
    [Trait("Category", "Integration")]
    public class UsersControllerTest : IClassFixture<IntegrationTestWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public UsersControllerTest(IntegrationTestWebApplicationFactory<Startup> webApplicationFactory)
        {
            _client = webApplicationFactory.CreateClient();
        }

        /// <summary>
        /// <see cref="UsersController.Get"/> が正常に動作することを確認します。
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get_Normal()
        {
            // Arrange
            var url = new Uri("http://localhost/api/users/1");

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UserViewModel>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.Equal("1", result.Id);
            Assert.Equal("Tanaka", result.FirstName);
            Assert.Equal("Taro", result.UserName);
        }

        /// <summary>
        /// <see cref="UsersController.Create"/> が正常に動作することを確認します。
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Create_Normal()
        {
            // Arrange
            var url = new Uri("http://localhost/api/users/");

           var model = new CreateUserViewModel
           {
               UserName = "Shiro",
               FirstName = "Takahashi",
               FamilyName = "Takahashi"
           };

           var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UserViewModel>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.Equal("Takahashi", result.FirstName);
            Assert.Equal("Shiro", result.UserName);
        }
    }
}
