using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using System.Net.Http;
using Newtonsoft.Json;
using Taskter.Core.Entities;
using System.Linq;

namespace Taskter.Tests.Helpers.Extensions
{
    static class HTTPClientProjectExtension
    {
        public static async Task<List<ProjectDTO>> GetProjectsForCurrentUser(this HttpClient client)
        {
            var response = await client.GetAsync("/api/users/current/projects");

            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProjectDTO>>(jsonResponse).ToList();
            return result;
        }
        public static async Task<ProjectDTO> GetProjectDetailsById(this HttpClient client, int projectID)
        {
            var response = await client.GetAsync($"/api/projects/{projectID}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProjectDTO>(jsonResponse);
            return result;
        }

        public static async Task<IEnumerable<UserDTO>> GetUsersByProjectId(this HttpClient client, int projectId)
        {
            var response = await client.GetAsync($"/api/projects/{projectId}/users");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(jsonResponse).ToList();
            return result;
        }

        public static async Task<IEnumerable<ProjectDTO>> GetAllProjects(this HttpClient client)
        {
            var response = await client.GetAsync("/api/projects");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProjectDTO>>(jsonResponse).ToList();
            return result;
        }

    }
}
