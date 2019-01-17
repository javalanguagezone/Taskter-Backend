using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectTaskEntryRepository : IRepository<ProjectTaskEntry>
    {
        ProjectTaskEntry AddTimeEntry(ProjectTaskEntry newProjectTaskEntry);
        IEnumerable<ProjectTaskEntry> GetProjectTaskEntriesByDate(int userId, DateTime date);
    }
}
