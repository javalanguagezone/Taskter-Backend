using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository {

        private readonly TaskterDbContext _context;
        public UserRepository (TaskterDbContext context) {
            _context = context;
        }
        public User GetCurrentUser () {
            return _context.Users.First();
        }

         public IEnumerable<Project> GetProjectsForCurrentUser()
         {
            var user = GetCurrentUser();
            var USER_PROJECTS = _context.UsersProjects.Where(up => up.UserId == user.Id).Select(up => up.Project)
            .Include(s => s.Client).Include(s => s.Tasks).ToList();
            
            return USER_PROJECTS;
         }

        public IEnumerable<ProjectTaskEntry> GetProjectTaskEntriesByDate(int year,int month, int day)
        {
            var user = GetCurrentUser();
            var USER_TASK_ENTRIES = _context.ProjectTaskEntres.Where(pr => pr.UserId == user.Id).Where(p => p.Date.Year == year && p.Date.Month==month && p.Date.Day==day).Include(pt=>pt.ProjectTask).ThenInclude(pr=>pr.Project).ThenInclude(c=>c.Client).ToList();

            return USER_TASK_ENTRIES;
        }
    }
}