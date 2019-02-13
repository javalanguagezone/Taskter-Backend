using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Taskter.Core.Interfaces
{
    public interface IUserProjectRepository
    {
        void InsertUserProjects(int projectID, ICollection<int> userIDs);
    }
}
