﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    [ApiController]
    public class ProjectController : ApplicationControllerBase
    {

        private readonly IProjectRepository _projectRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IProjectTaskRepository _projectTaskRepository;

        public ProjectController(IProjectRepository repository, IClientRepository clientRepository, IUserProjectRepository userProjectRepository, IProjectTaskRepository projectTaskRepository)
        {
            _projectRepository = repository;
            _userProjectRepository = userProjectRepository;
            _projectTaskRepository = projectTaskRepository;
        }
        [Route("/api/users/current/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsForCurrentUser()
        {
            var projectsRepo = _projectRepository.GetAllProjectsForCurrentUser();
            return Ok(projectsRepo.ToDTOList());
        }

        [Route("/api/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            var projectsRepo = _projectRepository.GetAllProjects();
            return Ok(projectsRepo.ToDTOList());
        }

        [Route("/api/projects/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectDetailsById(int id)
        {
            var projectsRepo = await _projectRepository.GetProjectDetailsById(id);

            return Ok(projectsRepo.ToDTO());
        }

        [Route("/api/projects/{id}/users")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByProjectId(int id)
        {
            var userProjectRepo = await _userProjectRepository.GetUsersByProjectId(id);

            List<User> users = new List<User>();

            foreach (var item in userProjectRepo)
            {
                users.Add(item.User);
            }

            return Ok(users.ToDTOList());
        }

        [Route("/api/project")]
        [HttpPost]
        public async Task<ActionResult> PostNewProject(ProjectInsertDTO project)
        {
            var projectId = await _projectRepository.AddProject(ProjectExtensions.ToEntity(project));
            _userProjectRepository.InsertUserProjects(projectId, project.UserIds);
            await _projectTaskRepository.AddProjectTasks(project.Tasks.ToProjectTaskList(projectId));
            return Ok();
        }

        [Route("api/projects/{id}/edit/basicinfo")]
        [HttpPut]
        public async Task<ActionResult> EditProjectBasicInfo(ProjectUpdateBasicDTO projectUpdateBasic)
        {
            var entry = await _projectRepository.GetProjectByIdAsync(projectUpdateBasic.ID);
            if (entry == null)
            {
                return NotFound();
            }
            await _projectRepository.UpdateBasic(entry, projectUpdateBasic.Name, projectUpdateBasic.Code);
            return NoContent();
        }

        [Route("api/projects/{id}/edit/users")]
        [HttpPut]
        public async Task<ActionResult> EditUsersOnProject(ProjectEditUsersDTO projectEditUsers)
        {
            var entry = await _userProjectRepository.GetUserByProjectId(projectEditUsers.ProjectId, projectEditUsers.UserId);
            if (entry == null)
            {
                return NotFound();
            }
            await _userProjectRepository.UpdateUserOnProject(entry, projectEditUsers.Active);
            return NoContent();
        }
        [Route("api/projects/{id}/edit/tasks")]
        [HttpPut]
        public async Task<ActionResult> EditTasksOnProject(List<ProjectEditTaskDTO> tasks)
        {
            foreach (var task in tasks)
            {
                try
                {
                    var modelTask = task.ToEntity();
                    if (task.ProjectTaskId == default(int))
                    {

                        await _projectTaskRepository.AddProjectTask(modelTask);
                    }
                    else
                    {
                        await _projectTaskRepository.UpdateProjectTask(task.ToEntity());
                    }
                }
                catch(Exception err)
                {
                    return BadRequest();
                }
            }
            await _projectTaskRepository.SaveChanges();
            return NoContent();
        }
    }
}
