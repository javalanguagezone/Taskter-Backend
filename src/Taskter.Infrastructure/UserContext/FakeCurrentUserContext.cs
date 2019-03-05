using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskter.Infrastructure.UserContext
{
    public class FakeCurrentUserContext: ICurrentUserContext
    {
        public int UserId { get; set; } = 1;
    }
}
