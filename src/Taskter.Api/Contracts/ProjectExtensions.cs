using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectExtensions 
    {
        public static ProjectUpdateDTO ToDTO (this Project project)
        {
            return new ProjectUpdateDTO() 
                {
                    ID = project.Id,
                    Name = project.Name,
                    ClientName = project.Client.Name,
                    ClientId = project.ClientId,
                    Code = project.Code,
                    Tasks = project.Tasks.ToDTOList()
                };
        }

        public static IEnumerable<ProjectUpdateDTO> ToDTOList (this IEnumerable<Project> projects) 
        {
            var projectsDTO = new List<ProjectUpdateDTO>();
            foreach (var proj in projects)
            {
                projectsDTO.Add(proj.ToDTO());
            }
            return projectsDTO;
        }

        public static Project ToEntity(this ProjectInsertDTO pidto)
        {
            return new Project(pidto.ProjectName, pidto.ClientId, pidto.ProjectCode);
        }
        
        public static Project ToEntity(this ProjectUpdateDTO prjuDTO)
        {
            return new Project(prjuDTO.Name, prjuDTO.ClientId, prjuDTO.Code) { Id = prjuDTO.ID };
        }
    }
}