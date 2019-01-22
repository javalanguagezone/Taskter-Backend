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
        public User GetUser (int userId) {
            return _context.Users.Find(userId);
        }

    }
}