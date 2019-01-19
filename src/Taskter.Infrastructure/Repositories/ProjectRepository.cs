using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories {
    public class ProjectRepository : IProjectRepository {
        private readonly TaskterDbContext _context;
        private readonly IUserRepository _userRepository;

        public ProjectRepository (TaskterDbContext context, IUserRepository userRepository) {
            _context = context;
            _userRepository = userRepository;
        }

        public void AddProject (Project prj) {
            _context.Projects.Add (prj);
            _context.SaveChanges ();
        }

        public IEnumerable<Project> GetAllProjectsForUser (int userId) {
            return _context.Projects.Where (pr => pr.Id == userId).Include (x => x.Tasks);
        }

        public IEnumerable<Project> GetProjectsForCurrentUser () {
            var user = _userRepository.GetCurrentUser ();
            var USER_PROJECTS = _context.UsersProjects.Where (up => up.UserId == user.Id).Select (up => up.Project)
                .Include (s => s.Client).Include (s => s.Tasks).ToList ();

            return USER_PROJECTS;
        }
    }
}