using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectExtensions 
    {
        public static ProjectDTO ToDTO (this Project project)
        {
            return new ProjectDTO() 
                {
                    ProjectID = project.Id,
                    ProjectName = project.Name,
                    ClientName = project.Client.Name,
                    ProjectCode = project.Code,
                    Tasks = project.Tasks.ToDTOList()
                };
        }

        public static IEnumerable<ProjectDTO> ToDTOList (this IEnumerable<Project> projects) 
        {
            var projectsDTO = new List<ProjectDTO>();
            foreach (var proj in projects)
            {
                projectsDTO.Add(proj.ToDTO());
            }
            return projectsDTO;
        }

        public static Project ToEntity(this ProjectInsertDTO pidto)
        {
            return new Project(pidto.ProjectName, pidto.Client.ClientId, pidto.ProjectCode);
        }
    }
}