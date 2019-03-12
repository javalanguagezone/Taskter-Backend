using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Taskter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Taskter.Infrastructure.Repositories;
using Taskter.Core.Entities;
using System.Linq;
using Taskter.Infrastructure.UserContext;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectEntryRepositoryTests
    {
        private ProjectTaskEntryRepository _repository;
        private TaskterDbContext _context;
        private CurrentUserContext _userContext;

        [SetUp]
        public void SetUp()
        {
            _context = new TaskterDbContext(new DbContextOptionsBuilder<TaskterDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            _context.Database.EnsureCreated();
            _userContext = new CurrentUserContext() { UserId = 4 };
            _repository = new ProjectTaskEntryRepository(_context, _userContext);
        }

        [Test]
        public async Task GetProjectTaskEntriesByDate_AddedTimeEntryForGivenDate_ReturnNonEmptyResult()
        {
            this._context.Users.Add(new User("UserTest", "User2", "User2", "Admin", "jkjkjk") { Id= _userContext.UserId});
            this._context.Clients.Add(new Client("testclient1"){Id = 1});
            this._context.Projects.Add(new Project("testProject1", 1, "examplecode"){Id = 1});
            this._context.ProjectTasks.Add(new ProjectTask("testTask1", 1, true){Id = 1});
            _context.SaveChanges();
            var newEntry = new ProjectTaskEntry(_userContext.UserId, 1, 50, new DateTime(2019, 2, 10), "Nasa nota"){Id = 50};

            await _repository.AddTimeEntry(newEntry);
            var result = await _repository.GetProjectTaskEntriesForCurrentUserByDate(2019, 2, 10);
            result.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetProjectTaskEntriesByDate_AddedTimeEntryForGivenDate_ShouldAddOnlyOneEntry()
        {
            this._context.Users.Add(new User("UserTest", "User2", "User2", "Admin", "jkjkjk") { Id= _userContext.UserId});
            this._context.Clients.Add(new Client("testclient1"){Id = 1});
            this._context.Projects.Add(new Project("testProject1", 1, "examplecode"){Id = 1});
            this._context.ProjectTasks.Add(new ProjectTask("testTask1", 1, true){Id = 1});
            _context.SaveChanges();
            
            var firstResult = await _repository.GetProjectTaskEntriesForCurrentUserByDate(2019, 2, 10);
            int numOfEnries = firstResult.ToList().Count;

            var newEntry = new ProjectTaskEntry(_userContext.UserId, 1, 50, new DateTime(2019, 2, 10), "Nasa nota"){Id = 50};
            await _repository.AddTimeEntry(newEntry);

            var result = await _repository.GetProjectTaskEntriesForCurrentUserByDate(2019, 2, 10);
            result.ToList().Count.Should().Be(numOfEnries + 1);
        }

        [Test]
        public async Task GetProjectTaskEntryById_ProjectTaskEntryIdIs10_ReturnsProjectTaskEntryWithId10()
        {
            this._context.Users.Add(new User("UserTest", "User2", "User2", "Admin", "jkjkjk") { Id = _userContext.UserId });
            this._context.Clients.Add(new Client("testclient1") { Id = 1 });
            this._context.Projects.Add(new Project("testProject1", 1, "examplecode") { Id = 1 });
            this._context.ProjectTasks.Add(new ProjectTask("testTask1", 1, true) { Id = 1 });
            _context.SaveChanges();
            var entry = new ProjectTaskEntry(_userContext.UserId, 1, 50, new DateTime(2019, 8, 3), "Note") { Id = 10 };

            await _repository.AddTimeEntry(entry);
            var result = await _repository.GetProjectTaskEntryByIdAsync(10);
            var projectTaskEntryInDb = _context.ProjectTaskEntries.Find(10);

            result.Should().NotBeNull();
            result.Id.Should().Be(10);
            result.Should().BeEquivalentTo(projectTaskEntryInDb);
        }

        [Test]
        public async Task UpdateTaskEntry_AddedTaskEntryAndChangedValues_ReturnsTaskEntryWithUpdatedValues()
        {
            // Arrange
            this._context.Users.Add(new User("UserTest", "User2", "User2", "Admin", "jkjkjk") { Id = _userContext.UserId });
            this._context.Clients.Add(new Client("testclient1") { Id = 1 });
            this._context.Projects.Add(new Project("testProject1", 1, "examplecode") { Id = 1 });
            this._context.ProjectTasks.Add(new ProjectTask("testTask1", 1, true) { Id = 1 });
            var entry = new ProjectTaskEntry(_userContext.UserId, 1, 50, new DateTime(2019, 8, 3), "Note") { Id = 55 };
            _context.ProjectTaskEntries.Add(entry);
            _context.SaveChanges();
            entry.DurationInMin = 100;

            // Act
            _repository.UpdateTaskEntry(entry);
            var updatedEntry = await _repository.GetProjectTaskEntryByIdAsync(55);

            // Assert
            updatedEntry.DurationInMin.Should().Be(100);
        }
  
    }
}
