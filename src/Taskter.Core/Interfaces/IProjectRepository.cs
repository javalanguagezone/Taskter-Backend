using System.Threading.Tasks;
﻿using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<int> AddProject(Project project);
        Task<IEnumerable<Project>> GetAllProjectsForCurrentUser();
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProjectDetailsById(int id);
    }
}
