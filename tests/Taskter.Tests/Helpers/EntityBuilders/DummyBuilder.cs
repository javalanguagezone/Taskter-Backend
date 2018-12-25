using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.EntityBuilders
{
    public class DummyBuilder
    {
        private readonly Dummy _dummy = new Dummy("Test");

        public Dummy Build() => _dummy;
    }
}
