using System;
using FluentAssertions;
using NUnit.Framework;
using Taskter.Core.Entities;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class ProjectTaskEntityTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_NameIsNullOrEmptyOrContainsOnlyWhitespaces_ThrowsArgumentException(string name)
        {
            Action result = () => new ProjectTask(name, 1, true);
            result.Should().Throw<ArgumentException>().WithMessage("Project task name cannot be null, empty or contain only whitespaces");
        }

        [TestCase(0)]
        [TestCase(-12)]
        public void Constructor_ProjectIdIsLessThan1_ThrowsArgumentException(int projectId)
        {
            Action result = () => new ProjectTask("test", projectId, true);
            result.Should().Throw<ArgumentException>().WithMessage("Project Id cannot be less than 1");
        }
    }
}