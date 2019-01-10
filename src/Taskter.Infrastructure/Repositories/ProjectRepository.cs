using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void AddProject(Project prj)
        {
            _context.Projects.Add(prj);
            _context.SaveChanges();
        }

        public IEnumerable<Project> GetAllProjectsForUser(int userId)
        {
            return _context.Projects.Where(pr => pr.Id == userId).Include(x => x.Tasks);
        }
    }
}
