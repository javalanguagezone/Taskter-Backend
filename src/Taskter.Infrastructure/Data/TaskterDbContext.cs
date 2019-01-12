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

        public DbSet<User> Users {get;set;}
        public DbSet<Client> Clients {get; set;}

        public DbSet<UserProject> UsersProjects {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Client
            //Name
            modelBuilder.Entity<Client>().Property(c => c.Name).IsRequired();
            

            //Project
                //Name
            modelBuilder.Entity<Project>().Property(p => p.Name).IsRequired();
                //Code
            modelBuilder.Entity<Project>().Property(p => p.Code).HasMaxLength(15);
            //Client relationship
            modelBuilder.Entity<Project>();
            
                 
            //ProjectTask
                //Name
            modelBuilder.Entity<ProjectTask>().Property(pt => pt.Name).IsRequired();
                //Billable
            modelBuilder.Entity<ProjectTask>().Property(pt => pt.Billable).IsRequired();
                   
        

            //User
                //Username
            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
                //Role
            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();
                //AvatarURL
            modelBuilder.Entity<User>().Property(u => u.AvatarURL).IsRequired();

                                         

           

           //UserProject
           modelBuilder.Entity<UserProject>()
                        .HasKey(up => new { up.UserId, up.ProjectId});
            
            modelBuilder.Entity<UserProject>()
                        .HasOne(up => up.User)
                        .WithMany(u => u.UsersProjects)
                        .HasForeignKey(up => up.UserId);
            
            modelBuilder.Entity<UserProject>()
                        .HasOne(up => up.Project)
                        .WithMany(p => p.UsersProjects)
                        .HasForeignKey(up => up.ProjectId);


            ModelBuilderExtensions.Seed(modelBuilder);

        }

        
    }
}
