using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public class ProjectGetDTO {
        public int ProjectID {get; set;}
        public string ProjectName { get; set; }
        public string ClientName { get; set; }

        public string ProjectCode { get; set; }
        public List<ProjectTaskGetDTO> Tasks { get; set; } = new List<ProjectTaskGetDTO> ();

    }
}