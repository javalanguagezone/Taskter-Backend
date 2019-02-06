using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Taskter.Api;
using Taskter.Tests.Helpers.Factories;
using Microsoft.Extensions.DependencyInjection;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.Repositories;
using Taskter.Infrastructure.UserContext;
using Taskter.Tests.Helpers.Extensions;
using Microsoft.AspNetCore.TestHost;
using System;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectControllerShould
    {
        private HttpClient _client;
        private ICurrentUserContext _currentUserContext;
        private TaskterDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public async Task GetProjectsForCurrentUser_SeededTwoProjectsInTest_ReturnsAListOfThoseTwoSeededProjects()
        {
            //refaktor u helper extenziju
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
            //
            //seed user
            _dbContext.Users.Add(new User("test1", "test 1", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            //seed projects
            var seedProjectsList = new List<Project>()
            {
                new Project("test project 1", 1, null) {Id = 10},
                new Project("test project 2", 1, null) {Id = 11}
            };

            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id =20},
                new ProjectTask("testTask2",10,false) {Id =21},
                new ProjectTask("testTask1",11,false) {Id =22},
                new ProjectTask("testTask2",11,false) {Id =23}
            };
            _dbContext.Projects.AddRange(seedProjectsList);
            _dbContext.ProjectTasks.AddRange(seedProjectsTaskList);
            //seed userProjects
            _dbContext.UsersProjects.Add(new UserProject(3, 10));
            _dbContext.UsersProjects.Add(new UserProject(3, 11));
            _dbContext.SaveChanges();
            //test
            _currentUserContext.UserId.Should().Be(3);
            var result = await _client.GetProjectsForCurrentUser();
            IEnumerable<ProjectDTO> seedsDTO = new List<ProjectDTO>();
            try
            {
                seedsDTO = seedProjectsList.ToDTOList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            result.Should().BeEquivalentTo(seedsDTO);
            var hw = "hw";
        }
    }
}
