using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddProjectTask(ProjectTask newTask)
        {
            List<ProjectTask> TaskArray = await _context.ProjectTasks.Where(t => t.ProjectId == newTask.ProjectId).ToListAsync();
            TaskArray.AddRange(_context.ProjectTasks.Local.Where(t => t.ProjectId == newTask.ProjectId).ToList());
            foreach (var x in TaskArray)
            {
                if(x.Name == newTask.Name && x.Billable == newTask.Billable)
                throw new Exception("Cannot add the same project twice");
            }
            await _context.ProjectTasks.AddAsync(newTask);
        }
        public async Task AddProjectTasks(List<ProjectTask> tasks)
        {
            await _context.ProjectTasks.AddRangeAsync(tasks);
            _context.SaveChanges();
        }

        public async Task UpdateProjectTask(ProjectTask task)
        {
            var entry = await _context.ProjectTasks.Where(prt => prt.Id == task.Id && prt.ProjectId == task.ProjectId).FirstOrDefaultAsync();
            entry.UpdateInfo(task.Name, task.Billable, task.Active);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}