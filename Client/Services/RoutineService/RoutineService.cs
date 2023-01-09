using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.RoutineService
{


    public class RoutineService : IRoutineService
    {
        // a list of workouts
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;
        public List<Routine> Routines { get; set; } = new List<Routine>();

        public RoutineService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }

        public async Task CreateRoutine(Routine routine)
        {
            var result = await _http.PostAsJsonAsync("api/routine", routine);
            var response = await result.Content.ReadFromJsonAsync<Routine>();
            // TODO: null check
            Routines.Add(response);
            _navManager.NavigateTo("routines");
        }

        public async Task DeleteRoutine(int id)
        {
            await _http.DeleteAsync($"api/routine/{id}");
            Routines.RemoveAt(Routines.FindIndex(r => r.Id == id));
            _navManager.NavigateTo("routines");
        }

        public async Task GetRoutines()
        {
            var result = await _http.GetFromJsonAsync<List<Routine>>("api/routine");
            if (result != null)
            {
                this.Routines = result;
            }
        }

        public async Task<Routine> GetSingleRoutine(int id)
        {
            var result = await _http.GetFromJsonAsync<Routine>($"api/routine/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Routine not found");
        }

        public async Task UpdateRoutine(Routine routine)
        {
            var result = await _http.PutAsJsonAsync($"api/routine/{routine.Id}", routine);
            var response = await result.Content.ReadFromJsonAsync<Routine>();
            // TODO: null check
            int index = Routines.FindIndex(r => r.Id == routine.Id);
            if (index != -1)
                Routines[index] = routine;
            _navManager.NavigateTo("meals");
        }
       

        // Task GetRoutines();
        // Task<Meal> GetSingleRoutine(int id);
        // Task CreateRoutine(Meal meal);
        // Task UpdateRoutine(Meal meal);
        // Task DeleteRoutine(int id);
    }
}
