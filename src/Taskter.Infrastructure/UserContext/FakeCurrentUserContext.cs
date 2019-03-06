using System;

namespace Taskter.Infrastructure.UserContext
{
    public class FakeCurrentUserContext : ICurrentUserContext
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
