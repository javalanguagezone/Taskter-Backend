using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Core.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        User GetCurrentUser();
    }
}