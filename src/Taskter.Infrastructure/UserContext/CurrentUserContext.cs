using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Taskter.Infrastructure.UserContext
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            var claimsPrincipal = httpContextAccessor.HttpContext.User;
            var stringUserId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            int.TryParse(stringUserId, out var userId);
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
