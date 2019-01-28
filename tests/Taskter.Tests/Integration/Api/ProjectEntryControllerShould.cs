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

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectEntryControllerShould
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().CreateClient();
        }

        [Test]
        public async Task ProjectTaskEntryShouldNotBeNull()
        {
            var insertModel = new ProjectTaskEntryInsertDTO()
            {
                UserId = 1,
                ProjectTaskId = 2,
                DurationInMin = 120,
                Day = new DateTime().Day,
                Month = new DateTime().Month,
                Year = new DateTime().Year,
                Note = ""

            };

            await _client.PostNewTimeEntry(insertModel);
            var result = await _client.GetTodaysEntries();

            result.Should().NotBeNullOrEmpty();
        }
    }
}
