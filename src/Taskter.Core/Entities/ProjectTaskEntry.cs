using System;
using System.Collections.Generic;
using System.Text;

namespace Taskter.Core.Entities
{
    class ProjectTaskEntry
    {
        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int durationInMin { get; set; }

        public DateTime Date { get; set; }
    }
}
