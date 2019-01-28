using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Project : BaseEntity {
        public string Name { get; private set; }
        public string Code { get ; private set; }
        

        public IEnumerable<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public IEnumerable<UserProject> UsersProjects {get; set;} = new List<UserProject>();

        public int ClientId { get; set; }
        public Client Client { get; set; }

        private Project()
        {
                
        }
        public Project (string name, int clientId, string code = null) {
           
           //todo validacija
            Name = name;
            Code = code;
            ClientId = clientId;
        }
    }
}