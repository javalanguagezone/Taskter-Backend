using System.Collections.Generic;
using System.Linq;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        public User getCurrentUser(){
            return new User("Mock", "https://images.vexels.com/media/users/3/145908/preview2/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg");
        }
    }
}
