using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            await _context.AddAsync(newProjectTaskEntry);
            await _context.SaveChangesAsync();

            return newProjectTaskEntry;
        }

        public async Task<IEnumerable<ProjectTaskEntry>> GetProjectTaskEntriesForCurrentUserByDate( int year, int month, int day)
        {
            return await _context.ProjectTaskEntries.Where(pr => pr.UserId == _userContext.UserId)
            .Where(p => p.Date.Year == year && p.Date.Month == month && p.Date.Day == day)
            .Include(pt => pt.ProjectTask).ThenInclude(pr => pr.Project)
            .ThenInclude(c => c.Client).ToListAsync();;
        }

    }
}