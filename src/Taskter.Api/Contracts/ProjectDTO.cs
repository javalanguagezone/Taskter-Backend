using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public class ProjectDTO {
        public int ProjectID {get; set;}
        public string ProjectName { get; set; }
        public string ClientName { get; set; }

        public string ProjectCode { get; set; }
        public ICollection<ProjectTaskDTO> Tasks { get; set; } = new List<ProjectTaskDTO> ();

    }
}