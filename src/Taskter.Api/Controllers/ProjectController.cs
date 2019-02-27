using Microsoft.AspNetCore.Mvc;
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

        [Route("api/projects/edit")]
        [HttpPost]
        public async Task<ActionResult> EditProject(ProjectInsertDTO project)
        {
            await _projectRepository.EditProject(ProjectExtensions.ToEntity(project), project.ID);
            return Ok();
        }   
    }
}
