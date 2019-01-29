using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class UserProjectEntityTests
    {
        [Test]
        public void Constructor_NegativeUserId_ThrowArgumentException()
        {
            Action act = () => new UserProject(-10, 10);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }

        [Test]
        public void Constructor_ZeroUserId_ThrowArgumentException()
        {
            Action act = () => new UserProject(0, 10);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }

        [Test]
        public void Constructor_NegativeProjectId_ThrowArgumentException()
        {
            Action act = () => new UserProject(10, -10);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }

        [Test]
        public void Constructor_ZeroProjectId_ThrowArgumentException()
        {
            Action act = () => new UserProject(10, 0);

            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }
    }
}
