using System.Collections.Generic;
using Taskter.Core.SharedKernel;
using Taskter.Core.Entities.Helpers;
namespace Taskter.Core.Entities {
    public class Client : BaseEntity {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                EntityValidaton.StringIsNullOrHasAWhiteSpace(value, "Client name");
                _name = value;
            }
        }

    
        public IEnumerable<Project> Projects {get; set;} = new List<Project>();
        private Client() {
        }
        public Client(string name)
        {
            Name = name;
        }

    }
}