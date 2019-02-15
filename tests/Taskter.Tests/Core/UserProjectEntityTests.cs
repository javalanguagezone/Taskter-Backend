using NUnit.Framework;
using System;
using Taskter.Core.Entities;
using FluentAssertions;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class UserProjectEntityTests
    {
        [TestCase(-10)]
        [TestCase(0)]
        public void Constructor_NegativeOrZeroUserId_ThrowArgumentException(int userId)
        {
            Action act = () => new UserProject(userId, 10);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }

        [TestCase(-10)]
        [TestCase(0)]   
        public void Constructor_NegativeOrZeroProjectId_ThrowArgumentException(int projectId)
        {
            Action act = () => new UserProject(10, projectId);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }
    }
}
