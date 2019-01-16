using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;


namespace Taskter.Api.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository) 
        {
            _repository = repository;
        }
        [Route("current")]
        [HttpGet]
        public ActionResult<UserGetDTO> GetCurrentUser() 
        {
            User currentUser = _repository.GetCurrentUser();
            return Ok(currentUser.ToDTO());
        }

        [Route("current/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectGetDTO>> GetProjectsForCurrentUser()
        {
            var projectsRepo = _repository.GetProjectsForCurrentUser();
            return Ok(projectsRepo.ToDTOList());
        }

        [Route("current/entries/{y}/{m}/{d}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectTaskEntryGetDTO>> GetProjectTaskEntriesByDate(int y, int m, int d)
        {
            var projectTasksRepo = _repository.GetProjectTaskEntriesByDate(y,m,d);
            return Ok(projectTasksRepo.ToDTOList());
        }
    }
}