using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public class ProjectInsertDTO 
    {
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectCode { get; set; }
        [Required]
        public ICollection<int> UserIds { get; set; }
        [Required]
        public ClientInsertDTO Client { get; set; }
        [Required]
        public ICollection<ProjectTaskInsertDTO> Tasks { get; set; }
    }
}