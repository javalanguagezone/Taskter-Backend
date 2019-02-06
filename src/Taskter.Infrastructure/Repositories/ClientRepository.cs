using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;
using Taskter.Infrastructure.Data;

namespace Taskter.Infrastructure.Repositories
{
    class ClientRepository:IClientRepository
    {
        private readonly TaskterDbContext _context;
        public ClientRepository (TaskterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}