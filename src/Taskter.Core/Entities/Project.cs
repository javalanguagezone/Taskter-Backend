using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Project : BaseEntity {
        public string Name { get; set; }
        public string Code {
            get { return Code; }
            set {
                Code = value.Trim();
            }
        }
        public Client Client { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }
        public ICollection<UserProject> UsersProjects {get; set;}


        public Project (string name, string code = "") {
            Tasks = new List<ProjectTask>();
            Name = name;
            Code = code.Trim();
        }
    }
}