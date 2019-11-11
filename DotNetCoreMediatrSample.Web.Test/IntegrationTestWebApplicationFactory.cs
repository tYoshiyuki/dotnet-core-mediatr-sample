using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreMediatrSample.Domain.Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreMediatrSample.Web.Test
{
    public class IntegrationTestWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                repository.Save(new User(new UserId("1"), new UserName("Taro"), new FullName("Tanaka", "Tanaka")));
                repository.Save(new User(new UserId("2"), new UserName("Jiro"), new FullName("Suzuki", "Suzuki")));
                repository.Save(new User(new UserId("3"), new UserName("Saburo"), new FullName("Sato", "Sato")));
            });
        }
    }
}
