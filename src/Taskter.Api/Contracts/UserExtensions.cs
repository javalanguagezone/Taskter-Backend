using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class UserExtensions
    {
        public static UserGetDTO ToDTO(this User user)
        {
            return new UserGetDTO()
            {
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                AvatarURL = user.AvatarURL,
            };
        }
    }
}
