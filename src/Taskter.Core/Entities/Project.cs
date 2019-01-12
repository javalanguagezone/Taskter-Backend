using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Project : BaseEntity {
        public string Name { get; set; }
        public string Code { get ; set; }
        

        public IEnumerable<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public IEnumerable<UserProject> UsersProjects {get; set;} = new List<UserProject>();

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Project()
        {
                
        }
        public Project (string name, string code = "") {
           
            Name = name;
            Code = code.Trim();
        }
    }
}