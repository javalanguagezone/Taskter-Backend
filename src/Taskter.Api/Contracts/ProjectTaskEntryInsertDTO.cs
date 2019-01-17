using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectTaskEntryInsertDTO
    {
        public int UserId { get; set; }
        public int ProjectTaskId { get; set; }
        public int DurationInMin { get; set; }
        public int Day {get; set;}
        public int Month{get; set;}
        public int Year{get; set;}
        public string Note { get; set; }

    }
}
