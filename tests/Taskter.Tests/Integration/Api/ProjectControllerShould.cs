using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using Taskter.Api;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Tests.Helpers.Factories;
using FluentAssertions;
using Taskter.Tests.Helpers.Extensions;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectControllerShould
    {
        private HttpClient _client;
        private IProjectRepository _repo;

        [SetUp]
        public void Setup()
        {
            _client = new IntegrationWebApplicationFactory<Startup>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    _repo = services.BuildServiceProvider().GetService<IProjectRepository>();
                });
            }).CreateClient();

        }

        // [Test]
        // public async Task ReturnOnlyProjects()
        // {
        //     _repo.AddProject(new Project()
        //     {
        //         Id = 3,
        //         Name = "Tada"
        //     });

        //     var response = await _client.GetAsync("/api/users/current/projects");
        //     response.EnsureSuccessStatusCode();
        //     var jsonResponse = await response.Content.ReadAsStringAsync();
        //     var result = JsonConvert.DeserializeObject<IEnumerable<Project>>(jsonResponse).ToList();

        //     result.Count().Should().NotBe(0);
        // }

       
        [Test]
        public async Task GetProjectsForCurrentUser()
        {
            var result = await _client.GetProjectsForCurrentUser();
            result.Should().NotBeNull();
            result.Count().Should().Be(1);

            result[0].ProjectName.Should().Be("Tracker2");
            result[0].ProjectCode.Should().Be("TA10002");
            result[0].ClientName.Should().Be("Tacta");
            result[0].Tasks.Count().Should().Be(4);
        }
    }
}
