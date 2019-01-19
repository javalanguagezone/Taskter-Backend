using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    [Route("api/entries")]
    [ApiController]
    public class ProjectTaskEntryController: ControllerBase
    {
        private readonly IProjectTaskEntryRepository _repository;
        public ProjectTaskEntryController(IProjectTaskEntryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult PostProjectTaskEntry(ProjectTaskEntryInsertDTO entry){

            _repository.AddTimeEntry(entry.ToEntity());

            return NoContent();
        }

        [Route("{year}/{month}/{day}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectTaskEntryDTO>> GetProjectTaskEntriesByDate(int year, int month, int day)
        {
            var projectTasksRepo = _repository.GetProjectTaskEntriesByDate(year,month, day);
            return Ok(projectTasksRepo.ToDTOList());
        }
    }
}
