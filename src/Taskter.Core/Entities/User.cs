using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class User:BaseEntity
    {
        public string Username {get; set;}

        public string AvatarURL {get; set;}

        public User (string username, string avatarURL){
            Username = username;
            AvatarURL=avatarURL; 
        }
    }
    
}