using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetUser(int userId);
    }
}