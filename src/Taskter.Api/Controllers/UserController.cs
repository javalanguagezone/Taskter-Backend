using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;


namespace Taskter.Api.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository){
            _repository = repository;
        }
        [Route("current")]
        [HttpGet]
        public ActionResult<User> Get(){
            User currentUser = _repository.GetCurrentUser(); 

            return Ok(currentUser);
        }
    }
}