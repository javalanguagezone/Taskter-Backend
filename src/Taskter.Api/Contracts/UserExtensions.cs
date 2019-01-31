using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class UserExtensions
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO()
            {
                UserId = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                AvatarURL = user.AvatarURL
            };
        }
    }
}
