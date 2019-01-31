using System;
using FluentAssertions;
using NUnit.Framework;
using Taskter.Core.Entities;


namespace Taskter.Tests.Core
{
    [TestFixture]
    public class UserEntityTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("Na me")]
        public void Constructor_UserNameIsNullHasWhiteSpacesOrIsAnEmptyString_ThrowsArgumentExceptions(string username)
        {
            Action result = () => new User(username, "test", "test", "test", "test");
            result.Should().Throw<ArgumentException>().WithMessage("Username property cannot be a null, an empty string or containt white spaces!");
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_FirstNameIsNullHasWhiteSpacesOrIsAnEmptyString_ThrowsArgumentExceptions(string firstname)
        {
            Action result = () => new User("test", firstname, "test", "test", "test");
            result.Should().Throw<ArgumentException>().WithMessage("First name cannot be a null, an empty string or containt white spaces!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_LastNameIsNullHasWhiteSpacesOrIsAnEmptyString_ThrowsArgumentExceptions(string lastname)
        {
            Action result = () => new User("test", "test", lastname, "test", "test");
            result.Should().Throw<ArgumentException>().WithMessage("Last name cannot be a null, an empty string or containt white spaces!");
        }


        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_RoleIsNullHasWhiteSpacesOrIsAnEmptyString_ThrowsArgumentExceptions(string role)
        {
            Action result = () => new User("test", "test", "test", role, "test");
            result.Should().Throw<ArgumentException>().WithMessage("Role cannot be a null, an empty string or containt white spaces!");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_AvatarURLIsNullHasWhiteSpacesOrIsAnEmptyString_ThrowsArgumentExceptions(string avatarURL)
        {
            Action result = () => new User("test", "test", "test", "test", avatarURL);
            result.Should().Throw<ArgumentException>().WithMessage("Avatar URL cannot be a null, an empty string or containt white spaces!");
        }
    }
}