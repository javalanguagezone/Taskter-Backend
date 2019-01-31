using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectTaskExtensions 
    {
        public static ProjectTaskDTO ToDTO (this ProjectTask task)
        {
            return new ProjectTaskDTO() 
                {
                    TaskID = task.Id,
                    Name = task.Name,
                    Billable = task.Billable
                 };
        }

        public static List<ProjectTaskDTO> ToDTOList (this IEnumerable<ProjectTask> tasks) 
        {
            var tasksDTO = new List<ProjectTaskDTO>();
            foreach (var tsk in tasks)
            {
                tasksDTO.Add(tsk.ToDTO());
            }
            return tasksDTO;
        }
    }
}