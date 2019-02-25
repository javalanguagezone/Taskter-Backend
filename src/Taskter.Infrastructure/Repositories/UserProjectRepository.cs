using System;
using System.Collections.Generic;
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
