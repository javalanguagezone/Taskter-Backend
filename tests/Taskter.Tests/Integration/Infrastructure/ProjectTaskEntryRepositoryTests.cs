using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Tests.Helpers;
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
            _context.SaveChanges();
            var newEntry = new ProjectTaskEntry(50, _userContext.UserId, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");

            await _repository.AddTimeEntry(newEntry);

            var result = await _repository.GetProjectTaskEntriesForCurrentUserByDate(2019, 2, 10);
            result.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetProjectTaskEntriesByDate_AddedTimeEntryForGivenDate_ShouldAddOnlyOneEntry()
        {
            this._context.Users.Add(new User("UserTest", "User2", "User2", "Admin", "jkjkjk") { Id = _userContext.UserId });
            _context.SaveChanges();

            var firstResult = await _repository.GetProjectTaskEntriesForCurrentUserByDate(2019, 2, 10);
            int numOfEnries = firstResult.ToList().Count;

            var newEntry = new ProjectTaskEntry(50, _userContext.UserId, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");
            await _repository.AddTimeEntry(newEntry);

            var result = await _repository.GetProjectTaskEntriesForCurrentUserByDate(2019, 2, 10);
            result.ToList().Count.Should().Be(numOfEnries + 1);
        }
    }
}
