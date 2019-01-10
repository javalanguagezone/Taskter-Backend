using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Username {get; set;}
        [Required]
        public string FirstName {get; set;}
        [Required]
        public string LastName {get; set;}
        [Required]
        public string Role {get; set;}
        public string AvatarURL {get; set;}
        public int ProjectUserId { get; set; }

        public ICollection<ProjectUser> ProjectUsers { get; set; }



        public User (string username, string avatarURL, string firstName, string lastName, string role){
            Username = username;
            AvatarURL=avatarURL; 
            FirstName = firstName;
            LastName = lastName; 
            Role = role; 
        }
    }
    
}