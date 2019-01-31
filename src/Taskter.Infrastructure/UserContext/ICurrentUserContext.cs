using System;
using System.Collections.Generic;
using System.Text;

namespace Taskter.Infrastructure.UserContext
{
    
        public interface ICurrentUserContext
        {
            int UserId { get; set; }
        }
    
}
