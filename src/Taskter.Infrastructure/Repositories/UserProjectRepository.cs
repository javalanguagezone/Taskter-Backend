using System;
using System.Collections.Generic;
﻿using Microsoft.EntityFrameworkCore;
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
        public async Task<UserProject> GetUserByProjectId(int projectId, int userId)
        {
            var UserProject = await _context.UsersProjects.Where(up => up.ProjectId == projectId && up.UserId == userId).FirstOrDefaultAsync();

            return UserProject;
        }
        public async void InsertUserProjects(int projectID, ICollection<int> userIDs)
        {
            foreach (var id in userIDs)
            {
                await _context.UsersProjects.AddAsync(new UserProject(id, projectID));
            }
            _context.SaveChanges();            
        }
        public async Task UpdateUserOnProject(UserProject entry, bool active)
        {
            var UserProject = await _context.UsersProjects.FindAsync(entry.ProjectId, entry.UserId);
            if (UserProject == null)
                throw new Exception("UserProject not found!");
            UserProject.EditStatus(active);
            _context.UsersProjects.Update(UserProject);
            await _context.SaveChangesAsync();
        }
    }
}
