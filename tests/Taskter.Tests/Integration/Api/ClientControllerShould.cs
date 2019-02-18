using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Tests.Helpers.Extensions;
using Taskter.Tests.Helpers.Factories;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ClientControllerShould
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().CreateClient();
        }
        [Test]
        public async Task AddClients_AddOneClient_UpdatedDB()
        {
             
        }
        [Test]
        public async Task ReturnNonEmptyListWhenReturningAllClients()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 3 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            result.Should().NotBeNull();
        }
    }
}
