using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    [Route("/api/projects")]
    [ApiController]
    public class ProjectController: ControllerBase
    {
    
        private readonly IProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsForCurrentUser()
        {
            var projectsRepo = _repository.GetProjectsForCurrentUser();
            return Ok(projectsRepo.ToDTOList());
        }
    }
}
