﻿using Blazored.LocalStorage;
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
        private ILocalStorageService _localStorage;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();

        public ExerciseService(HttpClient http, NavigationManager navManager, ILocalStorageService localStorage)
        {
            _http = http;
            _navManager = navManager;
            _localStorage = localStorage;
        }

        public async Task CreateExercise(Exercise ex)
        {
            var result = await _http.PostAsJsonAsync("api/exercises", ex);
            var response = await result.Content.ReadFromJsonAsync<Exercise>();
            // TODO: null check
            Exercises.Add(response);
            // var workoutsInLocalStorage = await _localStorage.ContainKeyAsync("Workouts");
            // if (workoutsInLocalStorage)
            // {
            //     var workouts = await _localStorage.GetItemAsync<List<Workout>>("Workouts");
            //     var index = workouts.FindIndex(w => w.Id == response.WorkoutId);
            //     if (index != -1)
            //     {
            //         workouts[index].Exercises.Add(response);
            //         await _localStorage.SetItemAsync("Workouts", workouts);
            //     }
            // }
            _navManager.NavigateTo($"workout/{response.WorkoutId}");
        }

        public async Task DeleteExercise(int id)
        {
            await _http.DeleteAsync($"api/Exercises/{id}");
            Exercises.RemoveAt(Exercises.FindIndex(r => r.Id == id));
            // await _localStorage.RemoveItemAsync("Workouts");
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
            var result = await _http.GetFromJsonAsync<Exercise>($"api/Exercises/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Exercise not found");
        }

        public async Task UpdateExercise(Exercise ex)
        {
            var result = await _http.PutAsJsonAsync($"api/Exercises/{ex.Id}", ex);
            var response = await result.Content.ReadFromJsonAsync<Exercise>();
            // TODO: null check
            int index = Exercises.FindIndex(e => e.Id == ex.Id);
            if (index != -1)
                Exercises[index] = ex;
            // await _localStorage.RemoveItemAsync("Workouts");
            _navManager.NavigateTo($"workout/{response.WorkoutId}");
        }
    }
}
