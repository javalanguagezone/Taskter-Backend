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
    public static class HttpClientUserExtension
    {
        public static async Task<User> GetCurrentUser(this HttpClient client)
        {
            var response = await client.GetAsync("/api/users/current");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            
            var result = JsonConvert.DeserializeObject<User>(jsonResponse);
            return result;
        }

    }
}
