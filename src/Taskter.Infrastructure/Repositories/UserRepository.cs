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
    }
}