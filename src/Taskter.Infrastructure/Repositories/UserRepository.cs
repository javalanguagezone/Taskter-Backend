using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TaskterDbContext _context;
        public UserRepository(TaskterDbContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

    }
}