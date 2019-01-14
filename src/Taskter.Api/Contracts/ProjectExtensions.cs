using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectExtensions 
    {
        public static ProjectGetDTO ToDTO (this Project project)
        {
            return new ProjectGetDTO() 
                {
                    Name = project.Name,
                    ClientName = project.Client.Name,
                    Code = project.Code
                }.AppendTasks(project.Tasks);
        }

        public static IEnumerable<ProjectGetDTO> ToDTOList (this IEnumerable<Project> projects) 
        {
            var projectsDTO = new List<ProjectGetDTO>();
            foreach (var proj in projects)
            {
                projectsDTO.Add(proj.ToDTO());
            }
            return projectsDTO;
        }
    }
}