using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.Extensions
{
    public static class HttpClientClientExtension
    {
        public static async Task<IEnumerable<Client>> GetAllClients(this HttpClient client)
        {
            var response = await client.GetAsync("/api/clients");
            response.EnsureSuccessStatusCode();
            var jsonResponse =await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<Client>>(jsonResponse);
            return result;
        }
    }
}
