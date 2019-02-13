using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Core.Interfaces
{
    public interface IClientRepository: IRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<int> StoreNewClient(string name);
    }
}