using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskter.Api.Contracts
{
    public class ProjectUpdateBasicDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string  Code { get; set; }
    }
}
