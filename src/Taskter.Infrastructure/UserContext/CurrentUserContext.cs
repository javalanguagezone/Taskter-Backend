namespace Taskter.Infrastructure.UserContext
{
    public class CurrentUserContext : ICurrentUserContext
    {
        public int UserId { get; set; } = 1;
    }
}
