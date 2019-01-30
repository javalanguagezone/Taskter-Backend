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

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectEntryRepositoryTests
    {
        private ProjectTaskEntryRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var _context = new TaskterDbContext(new DbContextOptionsBuilder<TaskterDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);
            _context.Database.EnsureCreated();

            _repository = new ProjectTaskEntryRepository(_context);
        }

        [Test]
        public async Task GetProjectTaskEntriesByDate_AddedTimeEntryForGivenDate_ReturnNonEmptyResult()
        {
            var newEntry = new ProjectTaskEntry(50, 2, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");

            await _repository.AddTimeEntry(newEntry);

            var result = await _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            result.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetProjectTaskEntriesByDate_AddedTimeEntryForGivenDate_ShouldAddOnlyOneEntry()
        {
            var firstResult = await _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            int numOfEnries = firstResult.ToList().Count;
            
            var newEntry = new ProjectTaskEntry(50, 2, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");
            await _repository.AddTimeEntry(newEntry);

            var result = await _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            result.ToList().Count.Should().Be(numOfEnries + 1);
        }
    }
}
