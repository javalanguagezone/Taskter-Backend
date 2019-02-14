using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Taskter.Core.SharedKernel;
using Taskter.Core.Entities.Helpers;

namespace Taskter.Core.Entities
{
    public class Project : BaseEntity
    {
        private string _name;
        public string Name
        {
            get => this._name;
            private set
            {
                EntityValidaton.StringIsNullOrHasAWhiteSpace(value, "Project name");
                this._name = value;
            }
        }

        private string _code;

        public string Code
        {
            get => _code;
            private set
            {
                EntityValidaton.StringHasMoreThan15ParametersOrHasWhiteSpaces(value);
                _code = value;
            }

        }
        public IEnumerable<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public IEnumerable<UserProject> UsersProjects { get; set; } = new List<UserProject>();
        private int _clientId;
        public int ClientId
        {
            get => _clientId;
            private set 
            {
                EntityValidaton.ForeignKeyValueValidaton(value); 
                _clientId = value; 
            }
        }
        public Client Client { get; set; }

        private Project()
        {

        }
        public Project(string name, int clientId, string code = null)
        {
            Name = name;
            Code = code;
            ClientId = clientId;
        }
        
    }

}