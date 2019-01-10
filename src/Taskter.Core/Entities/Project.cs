using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace Taskter.Core.Entities
{
    public class Project : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        public string Client { get; set; }
        [Required]
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public int ProjectUserId { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }

        public Project(string name, string client, string code = "")
        {
            
            Name = name;
            Code = code;
            Client = client;
     
        }



    }
}
