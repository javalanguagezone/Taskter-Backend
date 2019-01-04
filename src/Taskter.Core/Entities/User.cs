using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class User:BaseEntity
    {
        public string Username {get; set;}

        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Role {get; set;}
        public string AvatarURL {get; set;}
        //Da li napraviti builder pattern?
        public User (string username, string avatarURL, string firstName, string lastName, string role){
            Username = username;
            AvatarURL=avatarURL; 
            FirstName = firstName;
            LastName = lastName; 
            Role = role; 
        }
    }
    
}