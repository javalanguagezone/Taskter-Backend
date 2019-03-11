using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectUpdateDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<int> UserIds { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public ICollection<ProjectTaskDTO> Tasks { get; set; }

       
    }
}
