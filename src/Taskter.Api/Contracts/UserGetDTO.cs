using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskter.Api.Contracts {
    public class UserGetDTO {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string AvatarURL { get; set; }
    }
}