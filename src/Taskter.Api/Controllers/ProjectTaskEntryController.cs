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
    public class ProjectTaskEntryController: ControllerBase
    {
        private readonly IProjectTaskEntryRepository _repository;
        public ProjectTaskEntryController(IProjectTaskEntryRepository repository)
        {
            _repository = repository;
        }

        [Route("api/eneries")]
        [HttpPost]
        public ActionResult<ProjectTaskEntryGetDTO> PostProjectTaskEntry(ProjectTaskEntryInsertDTO entry){

            _repository.AddTimeEntry(entry.ToEntity());

            return NoContent();
        }
    }
}
