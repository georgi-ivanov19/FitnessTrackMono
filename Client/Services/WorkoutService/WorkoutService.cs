using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace FitnessTrackMono.Client.Services.WorkoutService
{
    public class WorkoutService : IWorkoutService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;
        public List<Workout> Workouts { get; set; } = new List<Workout>();

        public WorkoutService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }
        public async Task CreateWorkout(Workout workout)
        {
            workout.Exercises = new List<Exercise>();
            var result = await _http.PostAsJsonAsync("api/workouts", workout);
            var response = await result.Content.ReadFromJsonAsync<Workout>();
            // TODO: null check
            Workouts.Add(response);
            _navManager.NavigateTo("routines");
        }

        public async Task DeleteWorkout(int id)
        {
            await _http.DeleteAsync($"api/workouts/{id}");
            Workouts.RemoveAt(Workouts.FindIndex(r => r.Id == id));
            _navManager.NavigateTo("routines");
        }

        public async Task<Workout> GetSingleWorkout(int id)
        {
            var result = await _http.GetFromJsonAsync<Workout>($"api/workouts/GetWorkout/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Workout not found");
        }

        public async Task GetWorkouts()
        {
            var result = await _http.GetFromJsonAsync<List<Workout>>($"api/workouts");
            if (result != null)
            {
                this.Workouts = result;
            }
        }

        public async Task UpdateWorkout(Workout workout)
        {
            var result = await _http.PutAsJsonAsync($"api/workouts/{workout.Id}", workout);
            var response = await result.Content.ReadFromJsonAsync<Workout>();
            // TODO: null check
            int index = Workouts.FindIndex(w => w.Id == workout.Id);
            if (index != -1)
                Workouts[index] = workout;
            _navManager.NavigateTo("routines");
        }
    }
}
