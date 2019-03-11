using System.Collections.Generic;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectTaskRepository
    {
        Task AddProjectTasks(List<ProjectTask> tasks);
        Task AddProjectTask(ProjectTask task);
        Task UpdateProjectTask(ProjectTask task);
        Task SaveChanges();
    }
}