using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class DummyExtensions
    {
        public static Dummy ToEntity(this DummyInsertDto dummy)
        {
            return new Dummy(dummy.Name);
        }
    }
}
