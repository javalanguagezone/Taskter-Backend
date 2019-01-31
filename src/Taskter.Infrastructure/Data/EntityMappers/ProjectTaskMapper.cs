using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;

namespace Taskter.Infrastructure.Data
{
    static class ProjectTaskMapper
    {
        public static void AddProjectTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>().Property(pt => pt.Name).IsRequired();

            modelBuilder.Entity<ProjectTask>().Property(pt => pt.Billable).IsRequired();

        }
    }
}
