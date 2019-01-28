using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class ProjectTask: BaseEntity
    {
        public string Name { get; set; }
        public bool Billable { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<ProjectTaskEntry> ProjectsTaskEntries { get; set; } = new List<ProjectTaskEntry>();


        private ProjectTask()
        {

        }
        public ProjectTask(string name, int projectId, bool billable)
        {
            Name = name;
            Billable = billable;
            ProjectId = projectId;
        }
    }
}