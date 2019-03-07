using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Core.Entities;
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
        public async Task AddClients_AddOneClient_AddOneClientToDBAndReturnOneRecorddMore()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                    _clientRepository = sp.GetRequiredService<IClientRepository>();
                });
            }
            ).CreateClient();

            var CurrentClientList = await _clientRepository.GetAllClients() as ICollection;
            var CurrentClientListLength = CurrentClientList.Count;
            _dbContext.Clients.Add(new Client("TestClient"));
            _dbContext.SaveChanges();
            var UpdatedClientList = await _clientRepository.GetAllClients() as ICollection;

            UpdatedClientList.Should().HaveCountGreaterThan(CurrentClientListLength);
    
        }
        [Test]
        public async Task AllClients_WhenDBNotEmpty_ReturnNonEmptyResult()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _clientRepository = sp.GetRequiredService<IClientRepository>();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Clients.Add(new Client("Test1"));
            _dbContext.SaveChanges();

            var result = await _clientRepository.GetAllClients();

            result.Should().NotBeNullOrEmpty();
        }
    }
}
