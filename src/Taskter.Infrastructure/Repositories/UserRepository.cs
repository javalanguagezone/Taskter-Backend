using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;
using System;

namespace Taskter.Infrastructure.Repositories {
    public class UserRepository : IUserRepository {

        private readonly TaskterDbContext _context;
        public UserRepository (TaskterDbContext context) {
            _context = context;
        }
        public User GetCurrentUser () {
            return _context.Users.Find(1);
        }

         public List<Project> GetProjectsForCurrentUser()
         {
            var user = GetCurrentUser();
            var USER_PROJECTS = _context.UsersProjects.Where(up => up.UserId == user.Id ).Include(up => up.Project).ToList();
            var currentUserProjects = new List<Project>();
            foreach (var item in USER_PROJECTS)
            {
               currentUserProjects.Add(item.Project);
            }
            return currentUserProjects;
         }
    }
}