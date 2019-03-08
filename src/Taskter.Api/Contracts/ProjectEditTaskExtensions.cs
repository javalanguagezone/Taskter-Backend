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
            if (dto.ProjectTaskId == default(int))
                return new ProjectTask(dto.Name, dto.ProjectId, dto.Billable) { Active = dto.Active };
            return new ProjectTask(dto.Name, dto.ProjectId, dto.Billable) { Id = dto.ProjectTaskId, Active = dto.Active };
        }
    }
}
