using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class User : BaseEntity
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            private set
            {
                UserNameValidation(value);
                _userName = value;
            }
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            private set
            {
                stringContainsOnlyWhiteSpacesIsNullOrIsEmpty(value, "First name");
                _firstName = value;
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            private set
            {
                stringContainsOnlyWhiteSpacesIsNullOrIsEmpty(value, "Last name");
                _lastName = value;
            }
        }

        public string _role;
        public string Role
        {
            get => _role;
            private set
            {
                stringContainsOnlyWhiteSpacesIsNullOrIsEmpty(value, "Role");
                _role = value;
            }
        }
        public string _avatarURL;

        public string AvatarURL
        {
            get => _avatarURL;
            private set
            {
                stringContainsOnlyWhiteSpacesIsNullOrIsEmpty(value, "Avatar URL");
                _avatarURL = value;
            }
        }
        public ICollection<UserProject> UsersProjects { get; set; } = new List<UserProject>();
        public ICollection<ProjectTaskEntry> UsersProjectsTaskEntries { get; set; } = new List<ProjectTaskEntry>();

        public User(string username, string firstName, string lastName, string role, string avatarURL)
        {
            UserName = username;
            AvatarURL = avatarURL;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        private User()
        {

        }
        private void UserNameValidation(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Contains(" "))
                throw new ArgumentException("Username property cannot be a null, an empty string or containt white spaces!");

        }

        private void stringContainsOnlyWhiteSpacesIsNullOrIsEmpty(string value, string propName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{propName} cannot be a null, an empty string or containt white spaces!");
        }
    }

}