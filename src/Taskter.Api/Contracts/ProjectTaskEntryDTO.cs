using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectTaskEntryDTO
    {
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectTask { get; set; }

        public string ClientName { get; set; }
        public int durationInMin { get; set; }
        public string Note { get; set; }

    }
}
