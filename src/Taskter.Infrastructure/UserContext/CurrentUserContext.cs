using System;
using System.Collections.Generic;
using System.Text;

namespace Taskter.Infrastructure.UserContext
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public int UserId { get; set; } = 1;
    }
}
