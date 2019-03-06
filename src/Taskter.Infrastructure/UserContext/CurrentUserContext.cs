using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Taskter.Infrastructure.UserContext
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            var claimsPrincipal = httpContextAccessor.HttpContext.User;
            var stringUserId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            Guid.TryParse(stringUserId, out var userId);
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
