using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IDummyRepository: IRepository<Dummy>
    {
        void AddDummy(Dummy dummy);
        void UpdateDummy(Dummy dummy);
    }
}
