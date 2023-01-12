using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.ExerciseService
{
    public class ExerciseService : IExerciseService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public ExerciseService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }
        public async Task CreateExercise(Exercise ex)
        {
            var result = await _http.PostAsJsonAsync("api/exercises", ex);
            var response = await result.Content.ReadFromJsonAsync<Exercise>();
            // TODO: null check
            Exercises.Add(response);
            _navManager.NavigateTo("routines");
        }

        public async Task DeleteExercise(int id)
        {
            await _http.DeleteAsync($"api/Exercises/{id}");
            Exercises.RemoveAt(Exercises.FindIndex(r => r.Id == id));
            _navManager.NavigateTo("routines");
        }

        public async Task GetExercises(int workoutId)
        {
            var result = await _http.GetFromJsonAsync<List<Exercise>>($"api/Exercises/GetExercises/{workoutId}");
            if (result != null)
            {
                this.Exercises = result;
            }
        }

        public async Task<Exercise> GetSingleExercise(int id)
        {
            var result = await _http.GetFromJsonAsync<Exercise>($"api/Exercises/GetExercise/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Exercise not found");
        }

        public async Task UpdateExercise(Exercise ex)
        {
            var result = await _http.PutAsJsonAsync($"api/workouts/{ex.Id}", ex);
            var response = await result.Content.ReadFromJsonAsync<Workout>();
            // TODO: null check
            int index = Exercises.FindIndex(ex => ex.Id == ex.Id);
            if (index != -1)
                Exercises[index] = ex;
            _navManager.NavigateTo("routines");
        }
    }
}
