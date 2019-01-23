using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using System.Net.Http;
using Newtonsoft.Json;
using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.Extensions
{
    static class HTTPProjectUserExtensions
    {
        public static async Task<ProjectDTO> GetProjectsForCurrentUser(this HttpClient client)
        {
            var response = await client.GetAsync("/api/users/current/projects");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsAsync<ProjectDTO>();

            //var result = JsonConvert.DeserializeObject<ProjectDTO>(jsonResponse);

            return jsonResponse;
        }
    }
}
