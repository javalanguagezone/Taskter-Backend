using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    [ApiController]
    public class ClientController:ApplicationControllerBase
    {

        private readonly IClientRepository _repository;

        public ClientController (IClientRepository repository)
        {
            _repository = repository;
        }

        [Route("/api/clients")]
        [HttpGet]
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _repository.GetAllClients();
        }
        [Route("/api/client")]
        [HttpPost]
        public async Task<ActionResult> StoreNewClient(ClientInsertDTO client)
        {
            await _repository.StoreNewClient(client.name);

            return Ok();
        }
    }
}