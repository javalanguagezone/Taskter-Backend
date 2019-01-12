// using FluentAssertions;
// using NUnit.Framework;
// using System.Linq;
// using System.Net;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Taskter.Api;
// using Taskter.Tests.Helpers.Extensions;
// using Taskter.Tests.Helpers.Factories;

// namespace Taskter.Tests.Integration.Api
// {
//     [TestFixture]
//     public class DummyControllerShould
//     {
//         private HttpClient _client;

//         [SetUp]
//         public void SetUp()
//         {
//             _client = new IntegrationWebApplicationFactory<Startup>().CreateClient();
//         }

//         [Test]
//         public async Task ReturnNoResultsIfDatabaseEmpty()
//         {
//             var result = await _client.GetAllDummies();

//             result.Should().NotBeNull();
//             result.Count().Should().Be(0);
//         }

//         [Test]
//         public async Task InsertOneDummy()
//         {
//             await _client.CreateDummy("Tarik");
//             var result = await _client.GetAllDummies();

//             result.Should().NotBeNull();
//             result.Count().Should().Be(1);
//             result.First().Name.Should().Be("Tarik");
//         }

//         [Test]
//         public async Task ReturnBadRequestIfNameIsNotProvided()
//         {
//             var result = await _client.CreateBadDummy();

//             result.IsSuccessStatusCode.Should().BeFalse();
//             result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
//         }
//     }
// }
