using System.Threading.Tasks;
﻿using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<int> AddProject(Project project);
        IEnumerable<Project> GetAllProjectsForCurrentUser();
        IEnumerable<Project> GetAllProjects();
        Task<Project> GetProjectDetailsById(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task UpdateBasic(Project entry, string name, string code);
    }
}
