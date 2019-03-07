using System;
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
        public async Task AddProjectTask(ProjectTask newTask)
        {
            var niz = _context.ProjectTasks.Local;
            foreach(var x in niz)
            {
                if(x.Name == newTask.Name && x.Billable == newTask.Billable)
                throw new Exception("Cannot add the same project twice");
            }
            await _context.ProjectTasks.AddAsync(newTask);
            _context.SaveChanges();
        }
        public async Task AddProjectTasks(List<ProjectTask> tasks)
        {
            await _context.ProjectTasks.AddRangeAsync(tasks);
            _context.SaveChanges();
        }
    }
}