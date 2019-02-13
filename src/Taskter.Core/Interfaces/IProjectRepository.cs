using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetAllProjectsForUser(int userId);
        Task<int> StoreNewProject(Project project);

    }
}
