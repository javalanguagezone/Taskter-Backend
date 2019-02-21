using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public class ProjectDTO {
        public int ID {get; set;}
        public string Name { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public IEnumerable<ProjectTaskDTO> Tasks { get; set; } = new List<ProjectTaskDTO> ();
       
    }
}