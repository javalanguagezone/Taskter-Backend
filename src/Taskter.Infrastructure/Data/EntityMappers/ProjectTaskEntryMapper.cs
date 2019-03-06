using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    static class ProjectTaskEntryMapper
    {
        public static void AddProjectTaskEntryMapping(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<ProjectTaskEntry>().Property(p => p.DurationInMin).IsRequired();
            modelBuilder.Entity<ProjectTaskEntry>().Property(p => p.Date).IsRequired();
            modelBuilder.Entity<ProjectTaskEntry>().HasKey(p => p.Id);

            modelBuilder.Entity<ProjectTaskEntry>()
                       .HasKey(up => up.Id);

            modelBuilder.Entity<ProjectTaskEntry>()
                        .HasOne(up => up.ProjectTask)
                        .WithMany(u => u.ProjectsTaskEntries)
                        .HasForeignKey(up => up.ProjectTaskId);
        }
    }
}
