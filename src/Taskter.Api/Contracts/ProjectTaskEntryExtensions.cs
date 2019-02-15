using System;
using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectTaskEntryExtensions
    {
        public static ProjectTaskEntryDTO ToDTO(this ProjectTaskEntry pte)
        {
            return new ProjectTaskEntryDTO()
            {
                Id = pte.Id,
                ProjectName = pte.ProjectTask.Project.Name,
                ProjectCode = pte.ProjectTask.Project.Code,
                ProjectTask = pte.ProjectTask.Name,
                ClientName = pte.ProjectTask.Project.Client.Name,
                durationInMin = pte.DurationInMin,
                Note = pte.Note
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
        public static ProjectTaskEntry ToEntity(this ProjectTaskEntryInsertDTO pte)
        {
            var newEntry = new ProjectTaskEntry(pte.UserId, pte.ProjectTaskId, pte.DurationInMin, new DateTime(pte.Year, pte.Month, pte.Day), pte.Note);
            return newEntry;
        }
    }
}
