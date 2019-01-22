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
    public class ProjectTaskEntryController: ApplicationControllerBase
    {
        private readonly IProjectTaskEntryRepository _repository;
        public ProjectTaskEntryController(IProjectTaskEntryRepository repository)
        {
            _repository = repository;
        }
        [Route("api/entries")]
        [HttpPost]
        public ActionResult PostProjectTaskEntry(ProjectTaskEntryInsertDTO entry){

            _repository.AddTimeEntry(entry.ToEntity());

            return NoContent();
        }

        [Route("api/users/current/entries/{year}/{month}/{day}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectTaskEntryDTO>> GetProjectTaskEntriesByDate(int year, int month, int day)
        {
            var projectTasksRepo = _repository.GetProjectTaskEntriesByDate(this.UserID,year,month, day);
            return Ok(projectTasksRepo.ToDTOList());
        }
    }
}
