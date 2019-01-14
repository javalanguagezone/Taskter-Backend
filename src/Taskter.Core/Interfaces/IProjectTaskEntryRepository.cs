using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectTaskEntryRepository : IRepository<ProjectTaskEntry>
    {
        IEnumerable<ProjectTaskEntry> GetByDateForUser(int userId, DateTime date);

    }
}
