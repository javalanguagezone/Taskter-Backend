﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class ProjectTask: BaseEntity
    {
        public string Name { get; set; }
        public bool Billable { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<ProjectTaskEntry> ProjectsTaskEntries { get; set; } = new List<ProjectTaskEntry>();


        public ProjectTask()
        {

        }
        public ProjectTask(string name, bool billable)
        {
            Name = name;
            Billable = billable;
        }
    }
}