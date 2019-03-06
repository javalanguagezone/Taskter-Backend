using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectEditUsersDTO
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
  
    }
}
