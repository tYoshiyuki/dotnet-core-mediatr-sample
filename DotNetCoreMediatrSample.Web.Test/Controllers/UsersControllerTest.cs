using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DotNetCoreMediatrSample.Web.ViewModel;
using Xunit;

namespace DotNetCoreMediatrSample.Web.Test.Controllers
{
    [Trait("Category", "Integration")]
    public class UsersControllerTest : IClassFixture<IntegrationTestWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public UsersControllerTest(IntegrationTestWebApplicationFactory<Startup> webApplicationFactory)
        {
            _client = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task Get()
        {
            // Arrange
            const string url = "/api/users/1";

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
    }
}
