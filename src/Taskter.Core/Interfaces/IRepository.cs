using System.Collections.Generic;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
