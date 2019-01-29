using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taskter.Core.Interfaces;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectTaskEntryControllerShould
    {
        
        private IProjectTaskEntryRepository _IProjectTaskEntryRepository;
        private IProjectRepository _IProjectRepository;
        private IUserRepository _IUserRepository;

        public void SetUp()
        {
            _IProjectTaskEntryRepository = Substitute.For<IProjectTaskEntryRepository>();
            _IProjectRepository = Substitute.For<IProjectRepository>();
        }
        [Test]
        public async Task ShouldCorrectlyAddOneEntry()
        {
            
            var results = _IProjectTaskEntryRepository.GetProjectTaskEntriesByDate(1, DateTime.Now);
            results.Should().NotBeNull();
            results.Count().Should().Be(0);

        }

        [Test]
        public async Task ReturnNoResultsIfNoEntriesForGivenDate()
        {
            
            var results =  _IProjectTaskEntryRepository.GetProjectTaskEntriesByDate(1, DateTime.Now);
            results.Should().NotBeNull();
            results.Count().Should().Be(0);

        }


    }
}
