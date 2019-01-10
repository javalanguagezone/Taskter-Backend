﻿using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        void AddProject(Project prj);
        IEnumerable<Project> GetAllProjectsForUser(int userId);
    }
}
