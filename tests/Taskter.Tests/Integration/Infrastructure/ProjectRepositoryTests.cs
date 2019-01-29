using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.Repositories;

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
            _repository = new ProjectRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public void GetAllProjectsForUser_UserIdIs4_ReturnsAListOfProjectsForUserWithId4()
        {
            
            //seed usera, seed projekte, dodijeli useru Projekte
            _context.Clients.Add(new Client("TestClient1"){Id = 5});
            _context.Users.Add(new User("test1","test1","test1","test1","test1"){Id = 3});
            _context.Users.Add(new User("test2","test2","test2","test2","test2"){Id = 4});
            //
            
            _context.Projects.Add(new Project("testProject1", 5,"testcode"){Id = 10});
            _context.Projects.Add(new Project("testProject2", 5,"testcode"){Id = 11});
            //
            _context.UsersProjects.Add(new UserProject(3,10));
            _context.UsersProjects.Add(new UserProject(4,10));
            _context.UsersProjects.Add(new UserProject(4,11));
            //
            _context.SaveChanges();

            



        }
    }
}