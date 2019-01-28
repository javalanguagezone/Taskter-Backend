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
            //kako ukloniti seedove koji se kreiraju prilikom svakog instanciranja taskterDBContexta ? seedovi su u core/data/taskterdbContext ??
            _context = new TaskterDbContext(new DbContextOptionsBuilder<TaskterDbContext>()
            .UseInMemoryDatabase("InMemoryTaskterDB")
            .Options);
            _context.Database.EnsureCreated();
           
            //global seeds go here
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
            //arange
            _context.Users.Add(new User("testUsername", "testFirstname", "testLastName", "Admin", "testUrl") { Id = 1 });
            _context.Users.Add(new User("testUsername2", "test2Firstname", "test2LastName", "Developer", "testUrl") { Id = 2 });
            _context.Users.Add(new User("testUsername3", "test3Firstname", "test3LastName", "Developer", "testUrl") { Id = 3 });
            //act
            var userInDb = _context.Users.Find(2);
            var result = await _repository.GetUser(2);
            //assert
            result.Should().BeEquivalentTo(userInDb);
        }

        [Test]
        public void testDbChangesEverytime()
        {
            var result = _context.Users.Local.Count();
            result.Should().Be(0);
        }
    }
}
