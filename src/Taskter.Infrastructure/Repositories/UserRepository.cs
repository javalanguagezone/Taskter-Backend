using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;


namespace Taskter.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {

        private readonly TaskterDbContext _context;
        public UserRepository(TaskterDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetProjectsForUser()
        {
            return _context.Projects.Join(_context.UsersProjects,
                z => z.Id,
                y => y.UserId,
                (z, y) => {
                    
                }
                );
               
        }
        public User GetCurrentUser(){
            return _context.Users.FirstOrDefault();
        }
    }
}
