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
        public ActionResult<UserGetDTO> GetCurrentUser() {
            User currentUser = _repository.GetCurrentUser();
            //UserDTO
            UserGetDTO user = new UserGetDTO() {
                 Username = currentUser.UserName,
                 FirstName = currentUser.FirstName,
                 LastName = currentUser.LastName,
                 Role = currentUser.Role,
                 AvatarURL = currentUser.AvatarURL,
              };

            return Ok(user);
        }

        [Route("current/projects")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectGetDTO>> GetProjectsForCurrentUser()
        {
            var projectsRepo = _repository.GetProjectsForCurrentUser();
            //projectsDTO
            var projectsDTO = new List<ProjectGetDTO>();
            foreach(var proj in projectsRepo)
            {
                projectsDTO.Add(
                    new ProjectGetDTO(){
                        Name = proj.Name,
                        ClientName = proj.Client.Name,
                        Code = proj.Code
                        }.AppendTasks(proj.Tasks)                 
                );
            }
            return Ok(projectsDTO);
        }
    }
}