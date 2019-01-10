using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IProjectTaskRepository : IRepository<ProjectTask>
    {
        void AddProjectTask(ProjectTask task);
    }
   
}
