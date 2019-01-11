using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    public class TaskterDbContext : DbContext
    {
        public TaskterDbContext(DbContextOptions<TaskterDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set;}
        public DbSet<ProjectTask> ProjectTasks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Project
            //Client
            modelBuilder.Entity<Project>()
                        .Property(p => p.Client)
                        .IsRequired();
            //Name
            modelBuilder.Entity<Project>()
                        .Property(p => p.Name)
                        .IsRequired();
            //Code
            modelBuilder.Entity<Project>()
                        .Property(p => p.Code)
                        .HasMaxLength(15);
                        
            //ProjectTask
            //Name
            modelBuilder.Entity<ProjectTask>()
                        .Property(pt => pt.Name)
                        .IsRequired();
            //Billable
            modelBuilder.Entity<ProjectTask>()
                        .Property(pt => pt.Billable)
                        .IsRequired();                                                           
        }
        

    }
}
