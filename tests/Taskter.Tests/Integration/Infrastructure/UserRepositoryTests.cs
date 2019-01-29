using System;
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
    }
}
