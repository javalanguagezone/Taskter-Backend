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

        public UserController(IUserRepository repository) {
            _repository = repository;
        }
        [Route("current")]
        [HttpGet]
        public ActionResult<User> GetCurrentUser() {
            User currentUser = _repository.GetCurrentUser();

            return Ok(currentUser);
        }

        [Route("current/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectGetDTO>> GetProjectsForCurrentUser()
        {
            var projs = _repository.GetProjectsForCurrentUser();
            return Ok(projs);
        }
    }
}