using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;
using Taskter.Infrastructure.UserContext;

namespace Taskter.Infrastructure.Repositories
{
    public class ProjectTaskEntryRepository : IProjectTaskEntryRepository
    {
        private readonly TaskterDbContext _context;
        private readonly ICurrentUserContext _userContext;


        public ProjectTaskEntryRepository(TaskterDbContext context, ICurrentUserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        public async Task<ProjectTaskEntry> AddTimeEntry(ProjectTaskEntry newProjectTaskEntry)
        {
            await _context.ProjectTaskEntries.AddAsync(newProjectTaskEntry);
            await _context.SaveChangesAsync();
            return newProjectTaskEntry;
        }

        public async Task<IEnumerable<ProjectTaskEntry>> GetProjectTaskEntriesForCurrentUserByDate(int year, int month, int day)
        {
            var entries = await _context.ProjectTaskEntries.Where(pr => pr.UserId == _userContext.UserId)
              .Where(p => p.Date.Year == year && p.Date.Month == month && p.Date.Day == day)
              .Include(pt => pt.ProjectTask).ThenInclude(pr => pr.Project)
              .ThenInclude(c => c.Client).ToListAsync();
            return entries;
        }
        public async Task<ProjectTaskEntry> GetProjectTaskEntryByIdAsync(int id)
        {
            return await _context.ProjectTaskEntries
            .Where(x => x.Id == id)
            .Include(pt => pt.ProjectTask)
            .FirstOrDefaultAsync();
        }

        public void UpdateTaskEntry(ProjectTaskEntry projectTaskEntry)
        {
            _context.SaveChanges();
        }
    }
}