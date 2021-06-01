using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PlannerApp.Shared;

namespace PlannerApp.Client.Services
{
    public class PlanDataService : IPlanDataService
    {
        private readonly HttpClient _httpClient;

        public PlanDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Plan> AddPlan(Plan plan)
        {
            var planJson =
                new StringContent(JsonSerializer.Serialize(plan), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/plan", planJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Plan>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeletePlan(int planId)
        {
            await _httpClient.DeleteAsync($"api/plan/{planId}");
        }

        public async Task<IEnumerable<Plan>> GetAllPlans()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Plan>>
                  (await _httpClient.GetStreamAsync($"api/plan"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Plan> GetPlanDetails(int planId)
        {
            return await JsonSerializer.DeserializeAsync<Plan>
                (await _httpClient.GetStreamAsync($"api/plan/{planId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdatePlan(Plan plan)
        {
            var planJson =
                 new StringContent(JsonSerializer.Serialize(plan), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/plan", planJson);
        }
    }
}
