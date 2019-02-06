using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public static IEnumerable<UserDTO> ToDTOList(this IEnumerable<User> users)
        {
            IEnumerable<UserDTO> UsersDTO = users.Select(u => u.ToDTO());
            return UsersDTO;
        }
    }
}
