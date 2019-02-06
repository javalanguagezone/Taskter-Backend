using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;


namespace Taskter.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ApplicationControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository) 
        {
            _repository = repository;
        }
        [Route("current")]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUser() 
        {
            User currentUser = await _repository.GetUser(this.UserID);
            return Ok(currentUser.ToDTO());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            IEnumerable<User> users = await _repository.GetAllUsers();
            return Ok(users.ToDTOList());
        }
    }
}