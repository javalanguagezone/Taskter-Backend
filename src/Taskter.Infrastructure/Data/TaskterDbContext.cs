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
    }
}
