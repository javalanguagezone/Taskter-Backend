using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Taskter.Api;
using Taskter.Tests.Helpers.Factories;
using Microsoft.Extensions.DependencyInjection;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.UserContext;
using Taskter.Tests.Helpers.Extensions;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework.Internal;
using Taskter.Core.Interfaces;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectControllerShould
    {
        private HttpClient _client;
        private ICurrentUserContext _currentUserContext;
        private TaskterDbContext _dbContext;
        private IProjectRepository _projectRepository;

        [Test]
        public async Task GetProjectsForCurrentUser_AssignedTwoProjects_ReturnsAListOfTwoAssignedProjects()
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
    
            _dbContext.Users.Add(new User("test1", "test 1", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            var clientSeed = new Client("testClient") { Id = 20 };
            _dbContext.Clients.Add(clientSeed);
            var seedProjectsList = new List<Project>()
            {
                new Project("test project 1", 20, null) {Id = 10, Client = clientSeed},
                new Project("test project 2", 20, null) {Id = 11, Client = clientSeed}
            };

            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id = 20},
                new ProjectTask("testTask2",10,false) {Id = 21},
                new ProjectTask("testTask1",11,false) {Id = 22},
                new ProjectTask("testTask2",11,false) {Id = 23}
            };
            _dbContext.Projects.AddRange(seedProjectsList);
            _dbContext.ProjectTasks.AddRange(seedProjectsTaskList);
            _dbContext.UsersProjects.Add(new UserProject(3, 10));
            _dbContext.UsersProjects.Add(new UserProject(3, 11));
            _dbContext.SaveChanges();

            var result = await _client.GetProjectsForCurrentUser();
            var seedsDto = seedProjectsList.ToDTOList();
            result.Should().BeEquivalentTo(seedsDto);
        }

        [Test]
        public async Task GetProjectsForCurrentUser_Assigned0Projects_ReturnsEmptyListAssignedProjects()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 4 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Users.Add(new User("test2", "test 2", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            _dbContext.SaveChanges();

            var result = await _client.GetProjectsForCurrentUser();
            result.Count.Should().Be(0);
        }

        [Test]
        public async Task GetProjectDetailsById_SeededThreeProjects_ReturnsDetailsAboutSecondSeededProject()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Clients.Add(new Client("TestClient1") { Id = 5 });
            _dbContext.Clients.Add(new Client("TestClient2") { Id = 6 });
            IEnumerable<Project> seedProjectList = new List<Project>()
            {
                new Project("testProject1", 5,"testcode001"){Id = 10},
                new Project("testProject2", 6,"testcode002"){Id = 11},
                new Project("testProject3", 6,"testcode003"){Id = 12}
            };
            IEnumerable<ProjectTask> seedProjectTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testProjectTask1", 10, true){Id = 20},
                new ProjectTask("testProjectTask2", 11, false){Id = 21},
                new ProjectTask("testProjectTask3", 11, true){Id = 22},
                new ProjectTask("testProjectTask4", 12, false){Id = 23}
            };
            _dbContext.Projects.AddRange(seedProjectList);
            _dbContext.ProjectTasks.AddRange(seedProjectTaskList);
            _dbContext.SaveChanges();

            var result = await _client.GetProjectDetailsById(seedProjectList.ToArray()[1].Id);
            result.Should().BeEquivalentTo(seedProjectList.ToArray()[1].ToDTO());
        }

        [Test]
        public async Task GetUsersByProjectId_SeededTwoUsersOnAProject_ReturnsAListOfTwoSeededUsers()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            var userSeedList = new List<User>()
            {
                new User("testUsername", "testFirstname", "testLastName", "Admin", "testUrl") {Id = 50},
                new User("testUsername2", "test2Firstname", "test2LastName", "Developer", "testUrl") {Id = 60}
            };
            var projectSeedList = new List<Project>()
            {
                new Project("testProject1", 5, null) {Id = 100},
                new Project("testProject2", 5, null) {Id = 110}
            };
            var usersProjectsList = new List<UserProject>()
            {
                new UserProject(50, 110),
                new UserProject(60, 110),
                new UserProject(50, 100)
            };
            _dbContext.Clients.Add(new Client("TestClient1") {Id = 50});
            _dbContext.Users.AddRange(userSeedList);
            _dbContext.Projects.AddRange(projectSeedList);
            _dbContext.UsersProjects.AddRange(usersProjectsList);
            _dbContext.SaveChanges();

            var result = await _client.GetUsersByProjectId(projectSeedList.ToArray()[1].Id);
            result.Count().Should().Be(2);
            result.Should().BeEquivalentTo(userSeedList.ToDTOList());
        }

        [Test]
        public async Task GetAllProjects_SeededZeroProjects_ReturnsNoProjects()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();
            var result = await _client.GetAllProjects();
            result.Count().Should().Be(0);
        }

        [Test]
        public async Task GetAllProjects_SeededThreeProjects_ReturnsAListOfThreeSeededProjects()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();
            _dbContext.Clients.Add(new Client("TestClient1") { Id = 5 });
            IEnumerable<Project> seedProjectList = new List<Project>()
            {
                new Project("testProject1", 5,"testcode001"){Id = 10},
                new Project("testProject2", 5,"testcode002"){Id = 11},
                new Project("testProject3", 5,"testcode003"){Id = 12}
            };
            _dbContext.Projects.AddRange(seedProjectList);
            _dbContext.SaveChanges();

            var result = await _client.GetAllProjects();
            result.Count().Should().Be(3);
            result.Should().BeEquivalentTo(seedProjectList.ToDTOList());
        }

        [Test]
        public async Task AddProject_AddOneProject_AddGivenProjectToDB()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                    _projectRepository = sp.GetRequiredService<IProjectRepository>();
                });
            }).CreateClient();

            var seed = new Project("Test1", 1);

            var id = await _projectRepository.AddProject(seed);
            
            _dbContext.SaveChanges();

            _dbContext.Projects.Find(id).Should().NotBeNull();
        }

        [Test]
        public async Task AddProject_AddMultipleProjects_AddGivenNumberOfProjects()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                    _projectRepository = sp.GetRequiredService<IProjectRepository>();
                });
            }).CreateClient();

            var seeds = new List<Project>() {
                new Project("Test1", 1),
                new Project("Test2", 1),
                new Project("Test3", 1)
            };

            foreach(var project in seeds){
                await _projectRepository.AddProject(project);
            }
            
            _dbContext.SaveChanges();

            _dbContext.Projects.ToList().Count.Should().Be(3);
        }
    }
}
