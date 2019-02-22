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
    public class ProjectController: ApplicationControllerBase
    {
    
        private readonly IProjectRepository _repository;
        private readonly IUserProjectRepository _userProjectRepository;
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IUserRepository _userRepository;

        public ProjectController(IProjectRepository repository, IUserRepository userRepo, IProjectTaskRepository projectTaskRepository, IUserProjectRepository userProjectRepository)
        {
            _repository = repository;
            _projectTaskRepository = projectTaskRepository;
            _userRepository = userRepo;
            _userProjectRepository = userProjectRepository;
        }
        [Route("/api/users/current/projects")]
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsForCurrentUser()
        {
            var projectsRepo = await _repository.GetAllProjectsForCurrentUser();
            return Ok(projectsRepo.ToDTOList());
        }

        [Route("/api/projects")]
        [HttpGet]
        public async Task <ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            var projectsRepo = await _repository.GetAllProjects();
            return Ok(projectsRepo.ToDTOList());
        }

        [Route("/api/projects/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectDetailsById(int id)
        {
            var projectsRepo = await _repository.GetProjectDetailsById(id);
            return Ok(projectsRepo.ToDTO());
        }

        [Route("/api/projects/{id}/users")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersByProjectId(int id)
        {
            var users = await _userRepository.GetUsersOnProject(id);
            return Ok(users.ToDTOList());
        }
        
        [Route("/api/project")]
        [HttpPost]
        public async Task<ActionResult> PostNewProject(ProjectInsertDTO project)
        {
            var projectId = await _repository.AddProject(ProjectExtensions.ToEntity(project));
            _userProjectRepository.InsertUserProjects(projectId, project.UserIds);
            await _projectTaskRepository.AddProjectTasks(project.Tasks.ToProjectTaskList(projectId));
            return Ok();
        }
    }
}
