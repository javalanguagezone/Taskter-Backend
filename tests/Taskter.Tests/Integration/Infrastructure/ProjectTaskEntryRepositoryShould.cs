using FluentAssertions;
using NUnit.Framework;
using System;
using Taskter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Taskter.Infrastructure.Repositories;
using Taskter.Core.Entities;
using System.Linq;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectEntryRepositoryShould
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
        public void AddEntry()
        {
            var newEntry = new ProjectTaskEntry(50, 2, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");

            _repository.AddTimeEntry(newEntry);

            var result = _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            result.Should().NotBeEmpty();
        }

        [Test]
        public void AddOnlyOneEntryOnSpecifiedDay()
        {
            int numOfEnries = _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10).ToList().Count;

            var newEntry = new ProjectTaskEntry(50, 2, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");
            _repository.AddTimeEntry(newEntry);

            var result = _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            result.ToList().Count.Should().Be(numOfEnries + 1);
        }
    }
}
