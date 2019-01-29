using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Taskter.Core.SharedKernel;

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
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Project name cannot be null or empty or contain only whitespace characters!");
                this._name = value;
            }
        }

        private string _code;

        public string Code
        {
            get => _code;
            private set
            {
                if (value != null)
                {
                    if (value.Length > 15)
                        throw new ArgumentException("Project code cannot contain more than 15 characters!");
                    if (value.Contains(" "))
                        throw new ArgumentException("Project code cannot contain whitespaces!");
                }
                _code = value;
            }

        }
        public IEnumerable<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public IEnumerable<UserProject> UsersProjects { get; set; } = new List<UserProject>();
        private int _clientId;
        public int ClientId
        {
            get => _clientId;
            set { _clientId = value; }
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