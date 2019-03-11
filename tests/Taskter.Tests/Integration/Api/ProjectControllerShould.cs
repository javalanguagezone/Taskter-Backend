﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Taskter.Api;
using Taskter.Tests.Helpers.Factories;
using Microsoft.Extensions.DependencyInjection;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.UserContext;
using Taskter.Tests.Helpers.Extensions;
using Microsoft.AspNetCore.TestHost;
using Taskter.Core.Interfaces;

namespace Taskter.Tests.Integration.Api
{
    [TestFixture]
    public class ProjectControllerShould
    {
        private HttpClient _client;
        private ICurrentUserContext _currentUserContext;
        private TaskterDbContext _dbContext;
        private IProjectRepository _projectRepository;

        [Test]
        public async Task GetProjectsForCurrentUser_AssignedTwoProjects_ReturnsAListOfTwoAssignedProjects()
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

            var seedProjectsTaskList = new List<ProjectTask>()
            {
                new ProjectTask("testTask1",10,false) {Id = 20},
                new ProjectTask("testTask2",10,false) {Id = 21},
                new ProjectTask("testTask1",11,false) {Id = 22},
                new ProjectTask("testTask2",11,false) {Id = 23}
            };
            _dbContext.Projects.AddRange(seedProjectsList);
            _dbContext.ProjectTasks.AddRange(seedProjectsTaskList);
            _dbContext.UsersProjects.Add(new UserProject(3, 10));
            _dbContext.UsersProjects.Add(new UserProject(3, 11));
            _dbContext.SaveChanges();

            var result = await _client.GetProjectsForCurrentUser();
            var seedsDto = seedProjectsList.ToDTOList();
            result.Should().BeEquivalentTo(seedsDto);
        }

        [Test]
        public async Task GetProjectsForCurrentUser_Assigned0Projects_ReturnsEmptyListAssignedProjects()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var serviceDesc = services.FirstOrDefault(desc => desc.ServiceType == typeof(ICurrentUserContext));
                    services.Remove(serviceDesc);
                    _currentUserContext = new CurrentUserContext() { UserId = 4 };
                    services.AddTransient<ICurrentUserContext>(x => _currentUserContext);
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();
                });
            }).CreateClient();

            _dbContext.Users.Add(new User("test2", "test 2", "test lastName", "admin", "http://google.com")
            { Id = _currentUserContext.UserId });
            _dbContext.SaveChanges();

            var result = await _client.GetProjectsForCurrentUser();
            result.Count.Should().Be(0);
        }

        [Test]
        public async Task EditProject_ChangeNameCodeClient_EditedProject()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();

                });
            }).CreateClient();

            var clientEntry1 = _dbContext.Clients.Add(new Client("ClientTest1"));
            var clientEntry2 = _dbContext.Clients.Add(new Client("ClientTest2"));

            var projectEntry = _dbContext.Projects.Add(new Project("TestProject", clientEntry1.Entity.Id, "2211"));
            var task = _dbContext.ProjectTasks.Add(new ProjectTask("TestTask", projectEntry.Entity.Id, true));
            
            _dbContext.SaveChanges();
            var project = await _client.GetProjectById(projectEntry.Entity.Id);
            
            project.Name = "ProjectTest";
            project.ClientId = clientEntry2.Entity.Id;
            project.Code = "1122";

            var editedProject = new ProjectUpdateDTO() {
                ID = projectEntry.Entity.Id,
                Name = project.Name,
                Code = project.Code,
                UserIds = new List<int>(){1,2},
                ClientName = project.ClientName,
                ClientId = project.ClientId,
                Tasks = null
            };

            await _client.EditProject(editedProject);
            _dbContext.SaveChanges();

            var result = await _client.GetProjectById(project.ID);

            result.Name.Should().Be("ProjectTest");
            result.ClientId.Should().Be(clientEntry2.Entity.Id);
            result.Code.Should().Be("1122");
        }

        [Test]
        public async Task EditProject_ChangeProjectUsers_EditedProject()
        {
            _client = new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    var sp = services.BuildServiceProvider();
                    _dbContext = sp.GetRequiredService<TaskterDbContext>();

                });
            }).CreateClient();

            var clientEntry1 = _dbContext.Clients.Add(new Client("ClientTest1"));

            var projectEntry = _dbContext.Projects.Add(new Project("TestProject", clientEntry1.Entity.Id, "2211"));
            _dbContext.ProjectTasks.Add(new ProjectTask("TestTask", projectEntry.Entity.Id, true));
            _dbContext.UsersProjects.Add(new UserProject(1, projectEntry.Entity.Id));
            _dbContext.SaveChanges();
            
            var project = await _client.GetProjectById(projectEntry.Entity.Id);

            var editedProject = new ProjectUpdateDTO() {
                ID = projectEntry.Entity.Id,
                Name = projectEntry.Entity.Name,
                Code = projectEntry.Entity.Code,
                UserIds = new List<int>(){2},
                ClientName = projectEntry.Entity.Client.Name,
                ClientId = projectEntry.Entity.Client.Id,
                Tasks = null
            };

            var result = await _client.EditProject(editedProject);
            _dbContext.SaveChanges();
            
            var userList = _dbContext.UsersProjects.Where(u => u.ProjectId == projectEntry.Entity.Id).ToList();
            
            userList.Count.Should().Be(1);
            userList[0].UserId.Should().Be(2);
        }
    }
}
