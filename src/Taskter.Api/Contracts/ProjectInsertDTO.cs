using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public class ProjectInsertDTO 
    {
        public string projectName { get; set; }
        public string projectCode { get; set; }
        public List<int> userIds { get; set; }
        public ClientInsertDTO client { get; set; }
        public List<ProjectTaskInsertDTO> tasks { get; set; }
    }
}