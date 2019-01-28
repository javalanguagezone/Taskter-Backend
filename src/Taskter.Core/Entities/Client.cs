using System.Collections.Generic;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Client : BaseEntity {
        public string Name { get; private set; }
        public IEnumerable<Project> Projects {get; set;} = new List<Project>();
        private Client() {
        }
        public Client(string name)
        {
            Name = name;
        }

    }
}