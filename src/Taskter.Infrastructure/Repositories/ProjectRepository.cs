using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskterDbContext _context;

        public ProjectRepository(TaskterDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> GetAllProjectsForUser(int userId)
        {
            var USER_PROJECTS = _context.UsersProjects.Where(up => up.UserId == userId)
            .Select(up => up.Project)
            .Include(s => s.Client).Include(s => s.Tasks).ToList();

            return USER_PROJECTS;
        }

    }
}