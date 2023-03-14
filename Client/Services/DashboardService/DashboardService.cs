using FitnessTrackMono.Shared.Models;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.DashboardService
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _http;

        public DashboardService(HttpClient http)
        {
            _http = http;
        }
        public async Task<DashboardResults> GetDashboardData(DateTime date)
        {
            var result = await _http.GetFromJsonAsync<DashboardResults>($"api/Dashboard?Date={date}");
            if (result == null)
                throw new Exception("No results found");
            return result;
        }
    }
}
