using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;
using Taskter.Tests.Helpers.Factories;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ClientControllerShould
    {
        private HttpClient _client;
        private IClientRepository _clientRepository;
        private TaskterDbContext _dbContext;

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
                   
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                    _clientRepository = sp.GetRequiredService<IClientRepository>();
                });
            }).CreateClient();

            var result = await _clientRepository.GetAllClients();

            result.Should().NotBeNull();
        }
    }
}
