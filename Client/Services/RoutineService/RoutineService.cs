using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.RoutineService
{


    public class RoutineService : IRoutineService
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;
        List<Routine> Routines { get; set; } = new List<Routine>();

        public RoutineService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }

        public Task CreateRoutine(Routine routine)
        {
            var result = await _http.PostAsJsonAsync("api/routine", routine);
            var response = await result.Content.ReadFromJsonAsync<Routine>();
            // TODO: null check
            Routines.Add(response);
            _navManager.NavigateTo("routines");
        }

        public Task DeleteRoutine(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetRoutines()
        {
            var result = await _http.GetFromJsonAsync<List<Routine>>("api/routine");
            if (result != null)
            {
                this.Routines = result;
            }
        }

        public Task<Meal> GetSingleRoutine(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRoutine(Meal meal)
        {
            throw new NotImplementedException();
        }
        // a list of workouts

        // Task GetRoutines();
        // Task<Meal> GetSingleRoutine(int id);
        // Task CreateRoutine(Meal meal);
        // Task UpdateRoutine(Meal meal);
        // Task DeleteRoutine(int id);
    }
}
