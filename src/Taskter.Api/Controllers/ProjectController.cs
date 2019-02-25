using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
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
        public async Task<ActionResult> EditProject(ProjectDTO project)
        {
            await _projectRepository.EditProject(ProjectExtensions.ToEntity(project), project.ID);
            return Ok();
        }

        [Route("api/projects/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetProjectById(int id)
        {
            var result = await _projectRepository.GetProjectById(id);
            return Ok(ProjectExtensions.ToDTO(result));
        }
        
       
    }
}
