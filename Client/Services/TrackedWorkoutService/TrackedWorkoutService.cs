using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace FitnessTrackMono.Client.Services.TrackedWorkoutService
{
    public class TrackedWorkoutService : ITrackedWorkoutService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;

        public TrackedWorkoutService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }
        public List<TrackedWorkout> TrackedWorkouts { get; set; } = new List<TrackedWorkout>();

        public async Task<TrackedWorkout> StartWorkout(Workout workout)
        {
            TrackedWorkout workoutToStart = new TrackedWorkout();
            workoutToStart.ParentWorkoutId = workout.Id;
            workoutToStart.TotalVolume = 0;
            workoutToStart.StartTime = DateTime.Now;
            var result = await _http.PostAsJsonAsync($"api/trackedworkouts", workoutToStart);
            var response = await result.Content.ReadFromJsonAsync<TrackedWorkout>();
            // TODO: null check
            TrackedWorkouts.Add(response);
            return response;
        }

        public async Task<TrackedWorkout> GetSingleWorkout(int id)
        {
            var result = await _http.GetFromJsonAsync<TrackedWorkout>($"api/trackedworkouts/GetWorkout/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Workout not found");
        }

        public async Task<TrackedWorkout?> GetLatestCompleted(int id)
        {
            var result = await _http.GetFromJsonAsync<TrackedWorkout>($"api/trackedworkouts/GetLatestCompleted/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task UpdateTrackedWorkout(TrackedWorkout workout)
        {
            var result = await _http.PutAsJsonAsync($"api/trackedworkouts/{workout.Id}", workout);
            var response = await result.Content.ReadFromJsonAsync<TrackedWorkout>();
            int index = TrackedWorkouts.FindIndex(w => w.Id == workout.Id);
            if (index != -1)
                TrackedWorkouts[index] = workout;
        }
    }
}
