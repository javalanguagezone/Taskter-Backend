using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectTaskEntryRepository : IRepository<ProjectTaskEntry>
    {
        Task<ProjectTaskEntry> AddTimeEntry(ProjectTaskEntry newProjectTaskEntry);
        Task<IEnumerable<ProjectTaskEntry>> GetProjectTaskEntriesByDate (int userId, int year, int month, int day);
    }
}
