using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectEditTaskDTO
    {
        public int ProjectId { get; set; }
        public int ProjectTaskId { get; set; }
        public string Name { get; set; }
        public bool Billable {get; set;} 
        public bool Active { get; set; }
    }
}
