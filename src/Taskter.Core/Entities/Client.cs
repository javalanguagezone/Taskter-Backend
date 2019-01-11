using System.Collections.Generic;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Client : BaseEntity {
        public string Name { get; set; }

        public ICollection<Project> Projects;
        public Client(string name)
        {
            Name = name;
        }

    }
}