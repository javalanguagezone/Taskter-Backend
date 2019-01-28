using FluentAssertions;
using NUnit.Framework;
using Taskter.Tests.Helpers.EntityBuilders;
using Taskter.Core.Entities;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class ProjectEntity
    {
        [Test]
        public void Constructor_ProjectName_ShouldContainAlphaNumericCharacters()
        {
            Project result = new Project("nesto",1, "nesto");
            result.Name.Should().NotBeNullOrWhiteSpace();

        }
        [Test]
        public void Constructor_invalidProjectName_ShouldThrowException()
        {
            Project result = new Project("",1,"nesto");
            result.Name.
        }
    }
}