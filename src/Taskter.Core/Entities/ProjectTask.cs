using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class ProjectTask : BaseEntity
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                stringEmptyNullOrOnlyWhitespaces(value);
                _name = value;
            }
        }
        public bool Billable { get; private set; }

        private int _projectId;
        public int ProjectId
        {
            get => _projectId;
            private set
            {
                KeyLessThan1(value);
                _projectId = value;
            }
        }
        public Project Project { get; set; }

        public ICollection<ProjectTaskEntry> ProjectsTaskEntries { get; set; } = new List<ProjectTaskEntry>();


        private ProjectTask()
        {

        }
        public ProjectTask(string name, int projectId, bool billable)
        {
            Name = name;
            Billable = billable;
            ProjectId = projectId;
        }

        private void stringEmptyNullOrOnlyWhitespaces(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                throw new ArgumentException("Project task name cannot be null, empty or contain only whitespaces");
        }
        private void KeyLessThan1(int key)
        {
            if (key < 1)
                throw new ArgumentException("Project Id cannot be less than 1");
        }
    }
}