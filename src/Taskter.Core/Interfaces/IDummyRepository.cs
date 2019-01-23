using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IDummyRepository : IRepository<Dummy>
    {
        IEnumerable<Dummy> GetAll();
        Dummy GetById(int id);
        void AddDummy(Dummy dummy);
        void UpdateDummy(Dummy dummy);
    }
}