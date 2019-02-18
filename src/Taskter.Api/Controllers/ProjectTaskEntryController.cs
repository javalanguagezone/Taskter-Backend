using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Interfaces;




namespace Taskter.Api.Controllers
{

    [ApiController]
    public class ProjectTaskEntryController : ApplicationControllerBase
    {
        private readonly IProjectTaskEntryRepository _repository;
        public ProjectTaskEntryController(IProjectTaskEntryRepository repository)
        {
            _repository = repository;
        }
        [Route("api/entries")]
        [HttpPost]
        public async Task<ActionResult> PostProjectTaskEntry(ProjectTaskEntryInsertDTO entry)
        {
            await _repository.AddTimeEntry(entry.ToEntity());
            return NoContent();
        }

        [Route("api/users/current/entries/{year}/{month}/{day}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTaskEntryDTO>>> GetProjectTaskEntriesForCurrentUserByDate(int year, int month, int day)
        {
            var projectTasksRepo = await _repository.GetProjectTaskEntriesForCurrentUserByDate(year, month, day);
            return Ok(projectTasksRepo.ToDTOList());
        }
    }
}
