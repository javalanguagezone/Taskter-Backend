using System;
using FluentAssertions;
using NUnit.Framework;
using Taskter.Core.Entities;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class ClientEntityTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Constructor_ProjectNameIsNullOrEmptyOrContainsOnlyWhitespaces_ThrowsArgumentException(string clientName)
        {
            Action result = () => new Client(clientName);
            result.Should().Throw<ArgumentException>().WithMessage("Client name cannot be null or empty or contain only whitespace characters!");
        }

    }

}