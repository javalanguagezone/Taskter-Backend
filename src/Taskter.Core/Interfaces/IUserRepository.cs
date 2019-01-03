using System.Collections.Generic;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
       User getCurrentUser();
    }
}