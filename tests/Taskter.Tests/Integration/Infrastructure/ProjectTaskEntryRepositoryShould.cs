using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Api.Contracts;
using Taskter.Tests.Helpers.Extensions;
using Taskter.Tests.Helpers.Factories;
using Taskter.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Taskter.Infrastructure.Repositories;
using Taskter.Core.Interfaces;
using Taskter.Core.Entities;
using System.Linq;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectEntryRepositoryShould
    {
        private TaskterDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TaskterDbContext(new DbContextOptionsBuilder<TaskterDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options);

            _context.Database.EnsureCreated();
        }
        [Test]
        public void AddEntry()
        {
            ProjectTaskEntryRepository _repository = new ProjectTaskEntryRepository(_context);

            var newEntry = new ProjectTaskEntry(50, 2, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");
            _repository.AddTimeEntry(newEntry);
            var result = _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            result.Should().NotBeEmpty();
        }
        
        [Test]
        public void AddOnlyOneEntryOnSpecifiedDay()
        {
            ProjectTaskEntryRepository _repository = new ProjectTaskEntryRepository(_context);
            int numOfEnries = _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10).ToList().Count;
            var newEntry = new ProjectTaskEntry(50, 2, 1, 50, new DateTime(2019, 2, 10), "Nasa nota");
            _repository.AddTimeEntry(newEntry);
            var result = _repository.GetProjectTaskEntriesByDate(2, 2019, 2, 10);
            result.ToList().Count.Should().Be(numOfEnries+1);
        }
    }
}
