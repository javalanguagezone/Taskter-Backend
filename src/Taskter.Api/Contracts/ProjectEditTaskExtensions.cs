using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectEditTaskExtensions
    {
        public static ProjectTask ToEntity(this ProjectEditTaskDTO dto)
        {
            if (dto.ProjectTaskId == 0)
                return new ProjectTask(dto.Name, dto.ProjectId, dto.Billable);
            return new ProjectTask(dto.Name, dto.ProjectId, dto.Billable) { Id = dto.ProjectTaskId };
        }
    }
}
