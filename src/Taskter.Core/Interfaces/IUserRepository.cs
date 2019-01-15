using System;
using System.Collections.Generic;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Core.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        IEnumerable<Project> GetProjectsForCurrentUser();
        IEnumerable<ProjectTaskEntry> GetProjectTaskEntriesByDate(int y, int m, int d);

        User GetCurrentUser();
    }
}