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
    public class ProjectController: ApplicationControllerBase
    {
    
        private readonly IProjectRepository _repository;
        private readonly IClientRepository _clientRepository;
        private readonly IUserProjectRepository _userProjectRepository;
        public ProjectController(IProjectRepository repository, IClientRepository clientRepository, IUserProjectRepository userProjectRepository)
        {
            _repository = repository;
            _clientRepository = clientRepository;
            _userProjectRepository = userProjectRepository;
        }
        [Route("/api/users/current/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsForCurrentUser()
        {
            var projectsRepo = _repository.GetAllProjectsForUser(this.UserID);
            return Ok(projectsRepo.ToDTOList());
        }
        
        [Route("/api/project")]
        [HttpPost]
        public async Task<ActionResult> PostNewProject(ProjectInsertDTO project)
        {
            var clientId = await _clientRepository.StoreNewClient(project.client.name);
            var projectId = await _repository.StoreNewProject(new Core.Entities.Project(project.projectName, clientId, project.projectCode));
            _userProjectRepository.InsertUserProjects(projectId, project.userIds);
            return Ok();
        }
    }
}
