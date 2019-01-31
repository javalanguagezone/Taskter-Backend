using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    static class UserProjectMapper
    {
        public static void AddUserProjectMapping(ModelBuilder modelBuilder) {


            
            modelBuilder.Entity<UserProject>()
                        .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProject>()
                        .HasOne(up => up.User)
                        .WithMany(u => u.UsersProjects)
                        .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProject>()
                        .HasOne(up => up.Project)
                        .WithMany(p => p.UsersProjects)
                        .HasForeignKey(up => up.ProjectId);
        }
    }
}
