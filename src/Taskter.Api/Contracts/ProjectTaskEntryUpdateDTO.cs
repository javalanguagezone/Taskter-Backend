using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectTaskEntryUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int ProjectTaskId { get; set; }
        [Required]
        public int durationInMin { get; set; }
        public string Note { get; set; }

    }
}