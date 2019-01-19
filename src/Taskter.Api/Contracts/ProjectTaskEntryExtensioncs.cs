using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectTaskEntryExtensioncs
    {
        public static ProjectTaskEntryDTO ToDTO(this ProjectTaskEntry pte)
        {
            return new ProjectTaskEntryDTO()
            {
                ProjectName = pte.ProjectTask.Project.Name,
                ProjectCode = pte.ProjectTask.Project.Code,
                ProjectTask = pte.ProjectTask.Name,
                ClientName = pte.ProjectTask.Project.Client.Name,
                durationInMin = pte.DurationInMin,
                Note=pte.Note
            };
        }

        public static IEnumerable<ProjectTaskEntryDTO> ToDTOList(this IEnumerable<ProjectTaskEntry> projectTaskEntries)
        {
            var projectsTaskEntriesDTO = new List<ProjectTaskEntryDTO>();
            foreach (var pte in projectTaskEntries)
            {
                projectsTaskEntriesDTO.Add(pte.ToDTO());
            }
            return projectsTaskEntriesDTO;
        }

        public static ProjectTaskEntry ToEntity( this ProjectTaskEntryInsertDTO pte){
            return new ProjectTaskEntry(){
                ProjectTaskId = pte.ProjectTaskId,
                UserId = pte.UserId,
                DurationInMin = pte.DurationInMin,
                Date = new DateTime(pte.Year, pte.Month, pte.Day),
                Note = pte.Note
            };
        }
    }
}
