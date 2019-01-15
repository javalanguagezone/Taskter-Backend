using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class ProjectTaskEntry : BaseEntity
    {
        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int durationInMin { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }
    }
}
