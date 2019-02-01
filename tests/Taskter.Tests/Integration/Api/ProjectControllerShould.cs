using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Taskter.Api;
using Taskter.Tests.Helpers.Factories;
using Microsoft.Extensions.DependencyInjection;
using Taskter.Infrastructure.UserContext;
using Taskter.Tests.Helpers.Extensions;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectControllerShould
    {
        private HttpClient _client;
        private ICurrentUserContext _currentUserContext;

        [SetUp]
        public void SetUp()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var sp = services.BuildServiceProvider();
                        _currentUserContext = sp.GetService<ICurrentUserContext>();
                    });
                }).CreateClient();
        }

        [Test]
        public async Task GetProjectsForCurrentUser_UserIDInCurrentUserContext_ReturnsANonEmptyList()
        {
            _currentUserContext.UserId.Should().BeGreaterThan(0);
            var result = await _client.GetProjectsForCurrentUser();
            result.Count.Should().NotBe(0);
        }
    }
}
