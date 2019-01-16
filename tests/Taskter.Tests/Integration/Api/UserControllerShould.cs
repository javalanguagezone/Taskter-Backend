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
    public class UserControllerShould
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().CreateClient();
        }

        [Test]
        public async Task ReturnOnlyOneCurrentUser(){

            var result = await _client.GetCurrentUser();

            result.Should().NotBeNull();
            result.FirstName.Should().Be("Nermin");

        }

        // [Test]
        // public  async Task ReturnProjectsOnlyForCurrentUser()
        // {
        //     var result = await _client.GetProjectsForCurrentUser();
            

        // }
    }
}
