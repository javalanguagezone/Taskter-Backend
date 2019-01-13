using System.Collections.Generic;
using Taskter.Core.SharedKernel;
using Taskter.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskter.Api.Contracts
{
    public class ProjectGetDTO {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        public IEnumerable<ProjectTask> Tasks { get; set; } = new List<ProjectTask> ();

        [NotMapped]
        public IEnumerable<UserProject> UsersProjects { get; set; } = new List<UserProject> ();

        [NotMapped]
        public int ClientId { get; set; }
        [Required]
        public Client Client { get; set; }

    }
}