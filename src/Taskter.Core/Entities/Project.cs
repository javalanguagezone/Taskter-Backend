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
        public string Client { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        // public int ProjectUserId { get; set; }
        // public ICollection<ProjectUser> ProjectUsers { get; set; }

        public Project (string name, string client, string code = "") {
            Name = name;
            Client = client;
            Code = code.Trim();
        }
    }
}