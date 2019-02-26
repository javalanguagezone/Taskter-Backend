using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    class UserProjectRepository : IUserProjectRepository
    {
        private readonly TaskterDbContext _context;

        public UserProjectRepository(TaskterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserProject>> GetUsersByProjectId(int projectId)
        {
            var usersProjects = await _context.UsersProjects.Where(x => x.ProjectId == projectId).Include(u => u.User).ToListAsync();

            return usersProjects;
        }

        public async void InsertUserProjects(int projectID, ICollection<int> userIDs)
        {
            foreach (var id in userIDs)
            {
                await _context.UsersProjects.AddAsync(new UserProject(id, projectID));

            }
            _context.SaveChanges();            
        }
    }
}
