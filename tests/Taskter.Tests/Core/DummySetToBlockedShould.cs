using FluentAssertions;
using NUnit.Framework;
using Taskter.Tests.Helpers.EntityBuilders;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class DummySetToBlockedShould
    {
        [Test]
        public void HaveStatusEqualsToBlocked()
        {
            var dummy = new DummyBuilder().WithName("Tarik").Build();

            dummy.SetToBlocked();

            dummy.Status.Should().Be("Blocked");
        }
    }
}
