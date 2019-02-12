using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ProjectExtension
    {
        public static Client getClient(this ProjectInsertDTO proj)
        {
            return new Client(proj.client.name);
        }
    }
}