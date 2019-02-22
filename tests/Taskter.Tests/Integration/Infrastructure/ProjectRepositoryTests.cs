using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.Repositories;
using Taskter.Infrastructure.UserContext;

namespace Taskter.Tests.Integration.Infrastructure
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        private ProjectRepository _repository;
        private TaskterDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TaskterDbContext(new DbContextOptionsBuilder<TaskterDbContext>()
            .UseInMemoryDatabase("InMemoryTaskterDB")
            .Options);
            _context.Database.EnsureCreated();
            var _userContext = new CurrentUserContext() { UserId = 4 };
            _repository = new ProjectRepository(_context, _userContext);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAllProjectsForUser_AssignedTwoProjectsToUserWhoseIdIs4_ReturnsAListOfTwoAssignedProjectsForUserWithId4()
        {

            _context.Clients.Add(new Client("TestClient1") { Id = 5 });
            _context.Users.Add(new User("test1", "test1", "test1", "test1", "test1") { Id = 3 });
            _context.Users.Add(new User("test2", "test2", "test2", "test2", "test2") { Id = 4 });

            IEnumerable<Project> seedProjectList = new List<Project>()
            {
                new Project("testProject1", 5,"testcode"){Id = 10},
                new Project("testProject2", 5,"testcode"){Id = 11}
            };
            _context.Projects.AddRange(seedProjectList);

            _context.UsersProjects.Add(new UserProject(3, 10));
            _context.UsersProjects.Add(new UserProject(4, 10));
            _context.UsersProjects.Add(new UserProject(4, 11));

            _context.SaveChanges();

            var result = await _repository.GetAllProjectsForCurrentUser();
            result.Count().Should().Be(2);
            result.Should().BeEquivalentTo(seedProjectList);
        }

        [Test]
        public async Task GetAllProjects_SeededThreeProjects_ReturnsAListOfThreeSeededProjects()
        {
            _context.Clients.Add(new Client("TestClient1") { Id = 5 });
            IEnumerable<Project> seedProjectList = new List<Project>()
            {
                new Project("testProject1", 5,"testcode001"){Id = 10},
                new Project("testProject2", 5,"testcode002"){Id = 11},
                new Project("testProject3", 5,"testcode003"){Id = 12}
            };
            _context.Projects.AddRange(seedProjectList);
            _context.SaveChanges();

            var result = await _repository.GetAllProjects();
            result.Count().Should().Be(3);
            result.Should().BeEquivalentTo(seedProjectList);
        }

        [Test]
        public async Task GetProjectDetailsById_SeededThreeProjects_ReturnsTheDetailsOfSecondProject()
        {
            _context.Clients.Add(new Client("TestClient1") { Id = 5 });
            _context.Clients.Add(new Client("TestClient2") { Id = 6 });
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
            _context.Projects.AddRange(seedProjectList);
            _context.ProjectTasks.AddRange(seedProjectTaskList);
            _context.SaveChanges();

            var result = await _repository.GetProjectDetailsById(seedProjectList.ToArray()[1].Id);
            result.Should().BeEquivalentTo(seedProjectList.ToArray()[1]);
        }
    }
}