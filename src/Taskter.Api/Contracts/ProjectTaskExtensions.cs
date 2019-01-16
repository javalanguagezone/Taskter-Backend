using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectTaskExtensions 
    {
        public static ProjectTaskGetDTO ToDTO (this ProjectTask task)
        {
            return new ProjectTaskGetDTO() 
                {
                    TaskID = task.Id,
                    Name = task.Name,
                    Billable = task.Billable
                 };
        }

        public static List<ProjectTaskGetDTO> ToDTOList (this IEnumerable<ProjectTask> tasks) 
        {
            var tasksDTO = new List<ProjectTaskGetDTO>();
            foreach (var tsk in tasks)
            {
                tasksDTO.Add(tsk.ToDTO());
            }
            return tasksDTO;
        }
    }
}