using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;

namespace Taskter.Tests.Helpers.Extensions
{
    public static class HttpClientProjectTaskEntryExtensions
    {
        public static async Task PostNewTimeEntry(this HttpClient client, ProjectTaskEntryInsertDTO model)
        {
            var insertModel = new ProjectTaskEntryInsertDTO()
            {
                UserId = model.UserId,
                ProjectTaskId = model.ProjectTaskId,
                DurationInMin = model.DurationInMin,
                Day = model.Day,
                Month = model.Month,
                Year = model.Year,
                Note = model.Note
            };


            var payload = JsonConvert.SerializeObject(insertModel);
            var response = await client.PostAsync("api/entries", new StringContent(payload, Encoding.UTF8, "application/json"));


            response.EnsureSuccessStatusCode();
        }

        public static async Task<List<ProjectTaskEntry>> GetTodaysEntries(this HttpClient client)
        {
            var today = new DateTime();

            var response = await client.GetAsync("api/users/current/entries/{" + today.Year.ToString() + "}/{" +
                today.Month.ToString() + "}/{" + today.Day.ToString() + "}");

            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ProjectTaskEntry>>(jsonResponse).ToList();
            return result;
        }
    }
}
