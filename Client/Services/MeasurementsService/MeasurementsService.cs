using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.MeasurementsService
{
    public class MeasurementsService : IMeasurementsService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;

        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
        public MeasurementsService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }

        public async Task GetMeasurements()
        {
            var result = await _http.GetFromJsonAsync<List<Measurement>>("api/measurement");
            if (result != null)
            {
                this.Measurements = result;
            }
        }

        public IEnumerable<Measurement> GetMeasurementsByType(string type)
        {
            return Measurements.Where(x => x.Type == type).OrderByDescending(x => x.Date);
        }

        public async Task<Measurement> GetSingleMeasurement(int id)
        {
            var result = await _http.GetFromJsonAsync<Measurement>($"api/measurement/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Measurement not found");
        }

        public async Task CreateMeasurement(Measurement measurement)
        {
            var result = await _http.PostAsJsonAsync("api/measurement", measurement);
            var response = await result.Content.ReadFromJsonAsync<Measurement>();
            // TODO: null check
            Measurements.Add(response);
            _navManager.NavigateTo("measurements");
        }

        public async Task UpdateMeasurement(Measurement measurement)
        {
            var result = await _http.PutAsJsonAsync($"api/measurement/{measurement.Id}", measurement);
            var response = await result.Content.ReadFromJsonAsync<Measurement>();
            // TODO: null check
            int index = Measurements.FindIndex(m => m.Id == measurement.Id);
            if (index != -1)
                Measurements[index] = measurement;
            _navManager.NavigateTo("measurements");
        }

        public async Task DeleteMeasurement(int id)
        {
            await _http.DeleteAsync($"api/measurement/{id}");
            Measurements.RemoveAt(Measurements.FindIndex(m => m.Id == id));
            _navManager.NavigateTo("measurements");
        }
    }
}
