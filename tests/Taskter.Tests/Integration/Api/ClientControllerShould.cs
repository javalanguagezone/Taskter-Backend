using FluentAssertions;
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

        public async Task ReturnNonEmptyListWhenReturningAllClients()
        {
            var result = await _client.GetAllClients();

            result.Should().NotBeNull();
        }
    }
}
