using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public class ProjectGetDTO {
        public string Name { get; set; }
        public string ClientName { get; set; }

        public string Code { get; set; }
        public List<ProjectTaskGetDTO> Tasks { get; set; } = new List<ProjectTaskGetDTO> ();

        public ProjectGetDTO AppendTasks (IEnumerable<ProjectTask> tasks) {
            foreach (var task in tasks) {
                Tasks.Add (new ProjectTaskGetDTO () {
                    Name = task.Name,
                    Billable = task.Billable
                });
            }
            return this;
        }
    }
}