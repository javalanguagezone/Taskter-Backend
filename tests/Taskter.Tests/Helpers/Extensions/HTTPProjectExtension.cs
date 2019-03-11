using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.Extensions
{
    public static class HTTPProjectExtension
    {
        public async static Task<ProjectDTO> GetProjectById(this HttpClient client, int id)
        {
            var response = await client.GetAsync("/api/projects/" + id);

            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProjectDTO>(jsonResponse);
            return result as ProjectDTO;
        }
        public async static Task<HttpResponseMessage> EditProject(this HttpClient client, ProjectUpdateDTO project)
        {
            var payload = JsonConvert.SerializeObject(project);
            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("api/projects/edit", httpContent);
            response.EnsureSuccessStatusCode();
            return response;
        }

    }   
}
