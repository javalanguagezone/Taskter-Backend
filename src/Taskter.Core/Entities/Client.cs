using System;
using System.Collections.Generic;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities {
    public class Client : BaseEntity {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                StringIsNullOrHasAWhiteSpace(value, "Client name");
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
        private void StringIsNullOrHasAWhiteSpace(string p, string propName)
        {
            if (string.IsNullOrWhiteSpace(p))
                throw new ArgumentException(propName + " cannot be null or empty or contain only whitespace characters!");

        }
    }
}