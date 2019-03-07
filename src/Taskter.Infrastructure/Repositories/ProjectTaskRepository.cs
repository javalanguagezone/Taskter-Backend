using System.Collections.Generic;
using System.Threading.Tasks;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly TaskterDbContext _context;
        public ProjectTaskRepository(TaskterDbContext context)
        {
            _context = context;
        }
        public async Task AddProjectTasks(List<ProjectTask> tasks)
        {
            await _context.ProjectTasks.AddRangeAsync(tasks);
            _context.SaveChanges();
        }
    }
}