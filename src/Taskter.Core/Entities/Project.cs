using System;
using System.Collections.Generic;
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
                StringIsNullOrHasAWhiteSpace(value, "Project name");
                this._name = value;
            }
        }

        private string _code;

        public string Code
        {
            get => _code;
            private set
            {
                StringHasMoreThan15CharactersOrHasWhiteSpaces(value);
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
                ForeignKeyValueValidaton(value);
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
        private void StringIsNullOrHasAWhiteSpace(string p, string propName)
        {
            if (string.IsNullOrWhiteSpace(p))
                throw new ArgumentException(propName + " cannot be null or empty or contain only whitespace characters!");

        }
        public static void StringHasMoreThan15CharactersOrHasWhiteSpaces(string p)
        {
            if (p != null)
            {
                if (p.Length > 15)
                    throw new ArgumentException("Project code cannot contain more than 15 characters!");
                if (p.Contains(" "))
                    throw new ArgumentException("Project code cannot contain whitespaces!");
            }
        }
        public static void ForeignKeyValueValidaton(int key)
        {
            if (key < 1)
                throw new ArgumentException("The ID value can not be less than one!");
        }
    }
}