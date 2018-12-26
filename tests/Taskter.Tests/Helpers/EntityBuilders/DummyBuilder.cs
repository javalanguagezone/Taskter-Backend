using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.EntityBuilders
{
    public class DummyBuilder
    {
        private readonly Dummy _dummy = new Dummy("Test");

        public DummyBuilder WithName(string name)
        {
            _dummy.Name = name;
            return this;
        }

        public Dummy Build() => _dummy;
    }
}
