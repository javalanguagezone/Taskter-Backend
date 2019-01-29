using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    public class ProjectTaskEntryRepository : IProjectTaskEntryRepository
    {
        private readonly TaskterDbContext _context;

        public ProjectTaskEntryRepository(TaskterDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectTaskEntry> GetProjectTaskEntriesByDate(int userId, DateTime date)
        {
            return _context.ProjectTaskEntres.Where((pr => pr.Id == userId))
            .Where(p => p.Date == date);

        }

        public ProjectTaskEntry AddTimeEntry(ProjectTaskEntry newProjectTaskEntry)
        {
            _context.Add(newProjectTaskEntry);
            _context.SaveChanges();

            return newProjectTaskEntry;
        }

        public IEnumerable<ProjectTaskEntry> GetProjectTaskEntriesByDate(int userId, int year, int month, int day)
        {
            var USER_TASK_ENTRIES = _context.ProjectTaskEntres.Where(pr => pr.UserId == userId)
            .Where(p => p.Date.Year == year && p.Date.Month == month && p.Date.Day == day)
            .Include(pt => pt.ProjectTask).ThenInclude(pr => pr.Project)
            .ThenInclude(c => c.Client).ToList();

            return USER_TASK_ENTRIES;
        }

    }
}