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

        [Route("api/users/current/entries/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectTaskEntryUpdateDTO>>> GetProjectTaskEntryByIdAsync(int id)
        {
            var projectTasksRepo = await _repository.GetProjectTaskEntryByIdAsync(id);
            if (projectTasksRepo == null)
            {
                return NotFound();
            }
            return Ok(projectTasksRepo.ToUpdateDTO());
        }



        [Route("api/users/current/entries")]
        [HttpPut]
        public async Task<ActionResult> UpdateTaskEntry(ProjectTaskEntryUpdateDTO editEntry)
        {

            var entry = await _repository.GetProjectTaskEntryByIdAsync(editEntry.Id);

            if (entry == null)
            {
                return NotFound();
            }




            entry.DurationInMin = editEntry.durationInMin;
            entry.Note = editEntry.Note;
            entry.ProjectTaskId = editEntry.ProjectTaskId;


            _repository.UpdateTaskEntry(entry);

            return NoContent();


        }
    }
}
