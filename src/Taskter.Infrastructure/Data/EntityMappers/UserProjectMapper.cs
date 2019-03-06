using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    internal static class UserProjectMapper
    {
        public static void AddUserProjectMapping(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<UserProject>()
                        .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProject>()
                        .HasOne(up => up.Project)
                        .WithMany(p => p.UsersProjects)
                        .HasForeignKey(up => up.ProjectId);
        }
    }
}
