using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class User : BaseEntity
    {
        public string UserName {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public string Role {get; set;}
        public string AvatarURL {get; set;}        
        public ICollection<UserProject> UsersProjects {get; set;} = new List<UserProject>();
        public ICollection<ProjectTaskEntry> UsersProjectsTaskEntries { get; set; } = new List<ProjectTaskEntry>();

        public User (string username, string firstName, string lastName, string role, string avatarURL)
        {
            UserName = username;
            AvatarURL=avatarURL; 
            FirstName = firstName;
            LastName = lastName; 
            Role = role; 
        }

        public User() { 
           
        }
    }
    
}