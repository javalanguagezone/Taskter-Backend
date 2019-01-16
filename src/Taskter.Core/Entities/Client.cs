using System.Collections.Generic;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Client : BaseEntity {
        public string Name { get; set; }
        public IEnumerable<Project> Projects = new List<Project>();
        public Client() {
        }
        public Client(string name)
        {
            Name = name;
        }

    }
}