using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.Repositories;

namespace Taskter.Tests.Integration.Infrastructure
{

    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository _repository;
        private TaskterDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TaskterDbContext(new DbContextOptionsBuilder<TaskterDbContext>()
            .UseInMemoryDatabase("InMemoryTaskterDB")
            .Options);
            _context.Database.EnsureCreated();
            _repository = new UserRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetUser_UserIdIs2_ReturnsUserWithId2()
        {
            _context.Users.Add(new User("testUsername", "testFirstname", "testLastName", "Admin", "testUrl") { Id = 1 });
            _context.Users.Add(new User("testUsername2", "test2Firstname", "test2LastName", "Developer", "testUrl") { Id = 2 });
            _context.Users.Add(new User("testUsername3", "test3Firstname", "test3LastName", "Developer", "testUrl") { Id = 3 });
            var userInDb = _context.Users.Find(2);
            var result = await _repository.GetUser(2);
            result.Should().BeEquivalentTo(userInDb);
        }

        [Test]
        public async Task GetUsersOnProject_SeededTwoUsersOnAProject_ReturnsAListOfTwoSeededUsers()
        {
            var userSeedList = new List<User>()
            {
                new User("testUsername", "testFirstname", "testLastName", "Admin", "testUrl") {Id = 5},
                new User("testUsername2", "test2Firstname", "test2LastName", "Developer", "testUrl") {Id = 6}
            };
            var projectSeedList = new List<Project>()
            {
                new Project("testProject1", 5, null) {Id = 10},
                new Project("testProject2", 5, null) { Id = 11}
            };
            var usersProjectsList = new List<UserProject>()
            {
                new UserProject(5, 11),
                new UserProject(6, 11),
                new UserProject(5, 10)
            };
            _context.Clients.Add(new Client("TestClient1") { Id = 5 });
            _context.Users.AddRange(userSeedList);
            _context.Projects.AddRange(projectSeedList);
            _context.UsersProjects.AddRange(usersProjectsList);
            _context.SaveChanges();

            var result = await _repository.GetUsersOnProject(projectSeedList.ToArray()[1].Id);
            result.Count().Should().Be(2);
            result.Should().BeEquivalentTo(userSeedList);
        }
    }
}
