using NUnit.Framework;
using System;
using Taskter.Core.Entities;
using FluentAssertions;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class UserProjectEntityTests
    {
        [Test]
        public void Constructor_NegativeOrZeroUserId_ThrowArgumentException()
        {
            Action act = () => new UserProject(Guid.Empty, 10);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }

        [TestCase(-10)]
        [TestCase(0)]   
        public void Constructor_NegativeOrZeroProjectId_ThrowArgumentException(int projectId)
        {
            Action act = () => new UserProject(Guid.NewGuid(), projectId);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }
    }
}
