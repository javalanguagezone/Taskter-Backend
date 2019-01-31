using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    static class ProjectMapper
    {
        public static void AddProjectMapping(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Project>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Project>().Property(p => p.Code).HasMaxLength(15);

            modelBuilder.Entity<Project>();
        }
    }
}
