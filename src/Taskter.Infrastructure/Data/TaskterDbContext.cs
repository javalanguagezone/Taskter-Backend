using Microsoft.EntityFrameworkCore;
using System;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    public class TaskterDbContext : DbContext
    {
        public TaskterDbContext(DbContextOptions<TaskterDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dummy> Dummies { get; set; }
        public DbSet<UserProject> UsersProjects { get; set; }

        public DbSet<ProjectTaskEntry> ProjectTaskEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            UserMapper.AddUserMapping(modelBuilder);
            ClientMapper.AddClientMapping(modelBuilder);
            ProjectMapper.AddProjectMapping(modelBuilder);
            ProjectTaskEntryMapper.AddProjectTaskEntryMapping(modelBuilder);
            ProjectTaskMapper.AddProjectTask(modelBuilder);
            UserProjectMapper.AddUserProjectMapping(modelBuilder);

            ModelBuilderExtensions.Seed(modelBuilder);

        }


    }
}
