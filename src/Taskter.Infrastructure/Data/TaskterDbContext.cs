using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    public class TaskterDbContext : DbContext
    {
        public TaskterDbContext(DbContextOptions<TaskterDbContext> options) : base(options)
        {

        }

        public DbSet<Dummy> Dummies { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Project> Projects { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        
    }
}
