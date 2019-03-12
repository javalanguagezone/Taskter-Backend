using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Core.Interfaces
{
    public interface IUserProjectRepository
    {
        void InsertUserProjects(int projectID, ICollection<int> userIDs);
        Task<IEnumerable<UserProject>> GetUsersByProjectId( int projectId);
        Task<UserProject> GetUserByProjectId(int projectId, int userId);
        Task UpdateUserOnProject(UserProject entry, bool active);
    }
}
