using System;
using System.Collections.Generic;
using System.Text;


namespace Taskter.Core.Entities
{
    public class ProjectUser
    {
        public int ProjectUserId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}