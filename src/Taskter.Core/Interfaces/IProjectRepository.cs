using System.Threading.Tasks;
﻿using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<int> AddProject(Project project);
        IEnumerable<Project> GetAllProjectsForCurrentUser();
        Task EditProject(Project project, int projectId);

        IEnumerable<Project> GetAllProjects();
        Task<Project> GetProjectDetailsById(int id);

    }
}
