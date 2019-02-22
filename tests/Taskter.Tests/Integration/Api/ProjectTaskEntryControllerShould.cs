using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Taskter.Api;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.UserContext;
using Taskter.Tests.Helpers.Factories;
using Taskter.Tests.Helpers.Extensions;
using Taskter.Api.Contracts;
using FluentAssertions;
using System.Net;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    class ProjectTaskEntryControllerShould
    {
        private HttpClient _client;
        private ICurrentUserContext _currentUserContext;
        private TaskterDbContext _dbContext;

        [Test]
        public async Task GetProjectTaskEntriesByDate_AddedTwoEntries_ReturnsAListOfTwoAddedEntries()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 3 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Users.Add(new User("test1", "test 1", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            var clientSeed = new Client("testClient") { Id = 20 };
            _dbContext.Clients.Add(clientSeed);
            var seedProjectsList = new List<Project>()
            {
                new Project("test project 1", 20, null) {Id = 10, Client = clientSeed},
                new Project("test project 2", 20, null) {Id = 11, Client = clientSeed}
            };
            _dbContext.AddRange(seedProjectsList);
            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id = 20, Project=seedProjectsList[0]},
                new ProjectTask("testTask2",10,false) {Id = 21, Project=seedProjectsList[1]}

            };
            var seedProjectsTaskEntryList = new List<ProjectTaskEntry>()
            {
                new ProjectTaskEntry(3,20,30,DateTime.Now, "Notee") {Id = 10, ProjectTask=seedProjectsTaskList[0]},
                new ProjectTaskEntry(3,21,50,DateTime.Now,"Notee") {Id = 11, ProjectTask=seedProjectsTaskList[1]}
            };
            _dbContext.ProjectTaskEntries.AddRange(seedProjectsTaskEntryList);
            _dbContext.SaveChanges();

            var result = await _client.GetProjectTaskEntriesByDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var seedsDto = seedProjectsTaskEntryList.ToDTOList();
            result.Should().BeEquivalentTo(seedsDto);
        }

        [Test]
        public async Task PostProjectTaskEntry_AssignTwoTaskEntriesToCurrentUser_ReturnsAListOfTwoAAssignedEntries()
        {

            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 3 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Users.Add(new User("test", "user1", "user1", "Admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            _dbContext.Clients.Add(new Client("Client") { Id = 100 });
            _dbContext.Projects.Add(new Project("Project 1", 100, null) { Id = 101 });
            _dbContext.ProjectTasks.Add(new ProjectTask("ProjectTask1", 101, true) { Id = 102 });
            _dbContext.ProjectTaskEntries.RemoveRange(_dbContext.ProjectTaskEntries.ToList());
            _dbContext.SaveChanges();
            ProjectTaskEntry newEntry = new ProjectTaskEntry(3, 102, 30, DateTime.Now, "Notee");
            ProjectTaskEntry newEntry2 = new ProjectTaskEntry(3, 102, 55, DateTime.Now, "Notee2");

            await _client.PostNewTimeEntry(newEntry);
            await _client.PostNewTimeEntry(newEntry2);

            var listOfEntries = _dbContext.ProjectTaskEntries.ToList();
            listOfEntries.Count.Should().Be(2);
        }

        [Test]
        public async Task GetProjectTaskEntryByIdAsync_AddedTwoTaskEntries_ReturnsEntryWithCorrectId()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 3 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Users.Add(new User("test1", "test 1", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            var clientSeed = new Client("testClient") { Id = 20 };
            _dbContext.Clients.Add(clientSeed);
            var seedProjectsList = new List<Project>()
            {
                new Project("test project 1", 20, null) {Id = 10, Client = clientSeed},
                new Project("test project 2", 20, null) {Id = 11, Client = clientSeed}
            };
            _dbContext.AddRange(seedProjectsList);
            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id = 20, Project=seedProjectsList[0]},
                new ProjectTask("testTask2",10,false) {Id = 21, Project=seedProjectsList[1]}

            };
            var seedProjectsTaskEntryList = new List<ProjectTaskEntry>()
            {
                new ProjectTaskEntry(3,20,30,DateTime.Now, "Notee") {Id = 10, ProjectTask=seedProjectsTaskList[0]},
                new ProjectTaskEntry(3,21,50,DateTime.Now,"Notee") {Id = 11, ProjectTask=seedProjectsTaskList[1]}
            };
            _dbContext.ProjectTaskEntries.AddRange(seedProjectsTaskEntryList);
            _dbContext.SaveChanges();

            var result = await _client.GetProjectTaskEntriesByIdAsync(10);
            var pteUpdateDTO = seedProjectsTaskEntryList[0].ToUpdateDTO();
            result.Should().BeEquivalentTo(pteUpdateDTO);
        }

        [Test]
        public async Task UpdateEntry_AddedOneEntryChangedValuesOfEntry_ReturnsNoContentAndUpdatedEntry()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 3 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Users.Add(new User("test1", "test 1", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            var clientSeed = new Client("testClient") { Id = 20 };
            _dbContext.Clients.Add(clientSeed);
            var seedProjectsList = new List<Project>()
            {
                new Project("test project 1", 20, null) {Id = 10, Client = clientSeed},
                new Project("test project 2", 20, null) {Id = 11, Client = clientSeed}
            };
            _dbContext.AddRange(seedProjectsList);
            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id = 20, Project=seedProjectsList[0]},
                new ProjectTask("testTask2",10,false) {Id = 21, Project=seedProjectsList[1]}

            };

            var taskEntry = new ProjectTaskEntry(3, 20, 30, DateTime.Now, "Notee") { Id = 10, ProjectTask = seedProjectsTaskList[0] };
                       
            _dbContext.ProjectTaskEntries.Add(taskEntry);
            _dbContext.SaveChanges();

            taskEntry.DurationInMin = 100;
            var result = await _client.UpdateTaskEntry(taskEntry.ToUpdateDTO());
            var updatedTaskEntry = await _client.GetProjectTaskEntriesByIdAsync(10);

            updatedTaskEntry.durationInMin.Should().Be(100);
            result.StatusCode.Should().BeEquivalentTo(System.Net.HttpStatusCode.NoContent);
        }

    }
}
