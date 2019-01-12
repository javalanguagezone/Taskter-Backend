// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;
// using Newtonsoft.Json;
// using Taskter.Api.Contracts;
// using Taskter.Core.Entities;

// namespace Taskter.Tests.Helpers.Extensions
// {
//     public static class HttpClientDummyExtension
//     {
//         public static async Task<List<Dummy>> GetAllDummies(this HttpClient client)
//         {
//             var response = await client.GetAsync("/api/dummies");
//             response.EnsureSuccessStatusCode();
//             var jsonResponse = await response.Content.ReadAsStringAsync();
//             var result = JsonConvert.DeserializeObject<IEnumerable<Dummy>>(jsonResponse).ToList();
//             return result;
//         }

//         public static async Task CreateDummy(this HttpClient client, string name)
//         {
//             var insertModel = new DummyInsertDto { Name = name };
//             var payload = JsonConvert.SerializeObject(insertModel);
//             var response = await client.PostAsync("/api/dummies", new StringContent(payload, Encoding.UTF8, "application/json"));
//             response.EnsureSuccessStatusCode();
//         }

//         public static async Task<HttpResponseMessage> CreateBadDummy(this HttpClient client)
//         {
//             return await client.PostAsync("/api/dummies", new StringContent(@"{}", Encoding.UTF8, "application/json"));
//         }
//     }
// }
