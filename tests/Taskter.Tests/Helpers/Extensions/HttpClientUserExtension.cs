using IdentityModel.Client;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Taskter.Tests.Helpers.Extensions
{
    public static class HttpClientUserExtension
    {
        public static async Task<UserInfoResponse> GetCurrentUser(this HttpClient client)
        {
            var response = await client.GetAsync("/api/users/current");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<UserInfoResponse>(jsonResponse);
            return result;
        }

    }
}
