using System;
using FluentAssertions;
using NUnit.Framework;
using Taskter.Core.Entities;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class ProjectEntityTests
    {

        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_ProjectNameIsNullOrEmptyOrContainsOnlyWhitespaces_ThrowsArgumentException(string projectName)
        {
            Action result = () => new Project(projectName, 1, "SCODE122");
            result.Should().Throw<ArgumentException>().WithMessage("Project name cannot be null or empty or contain only whitespace characters!");
        }

        [Test]
        public void Constructor_ProjectCodeExceeds15Characters_ThrowsArgumentException()
        {
            Action result = () => new Project("Test Name", 1, "123456789123457A");
            result.Should().Throw<ArgumentException>()
                .WithMessage("Project code cannot contain more than 15 characters!");

        }

        [Test]
        public void Constructor_ProjectCodeContainsWhitespaces_ThrowsArgumentException()
        {
            Action result = () => new Project("Test name", 1, "TE ST12");
            result.Should().Throw<ArgumentException>().WithMessage("Project code cannot contain whitespaces!");
        }

        [Test]
        public void Constructor_ClientIdIsLessThanOne_ThrowsArgumentException()
        {
            Action result = () => new Project("Test name", 0, "TEST13");
            result.Should().Throw<ArgumentException>().WithMessage("The ID value can not be less than one!");
        }
    }
}