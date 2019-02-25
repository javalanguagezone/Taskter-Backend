using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.UserContext;

namespace Taskter.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskterDbContext _context;
        private ICurrentUserContext _currentUserContext;


        public ProjectRepository(TaskterDbContext context, ICurrentUserContext currentUserContext) 
        {
            _context = context;
            _currentUserContext = currentUserContext;
        }
        public IEnumerable<Project> GetAllProjectsForCurrentUser()
        {
            var USER_PROJECTS = _context.UsersProjects.Where(up => up.UserId == _currentUserContext.UserId)
            .Select(up => up.Project)
            .Include(s => s.Client).Include(s => s.Tasks).ToList();

            return USER_PROJECTS;
        }

        public async Task<int> AddProject(Project project)
        {
            var proj = await _context.Projects.AddAsync(project);
            _context.SaveChanges();

            return proj.Entity.Id;
        }

        public async Task EditProject(Project editedProject, int projId)
        {
            var project = await _context.Projects.FindAsync(projId);

            if (project != null)
                project.Edit(editedProject.Name, editedProject.Code, editedProject.ClientId);

            _context.Projects.Update(project);
            _context.SaveChanges();

        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _context.Projects.Where(p => p.Id == id)
                .Include(c => c.Client)
                .Include(t => t.Tasks).SingleAsync();
        }
    }
}