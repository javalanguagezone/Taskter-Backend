using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Core.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetAllUsers();

    }
}