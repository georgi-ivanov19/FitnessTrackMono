using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.ExerciseSetService
{
    public class ExerciseSetService : IExerciseSetService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;
        public List<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();

        public ExerciseSetService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }

        public async Task CreateExerciseSet(ExerciseSet es)
        {
            var result = await _http.PostAsJsonAsync("api/ExerciseSets", es);
            var response = await result.Content.ReadFromJsonAsync<ExerciseSet>();
            // TODO: null check
            ExerciseSets.Add(response);
            _navManager.NavigateTo("workouts");
        }

        public async Task DeleteExerciseSet(int id)
        {
            await _http.DeleteAsync($"api/ExerciseSets/{id}");
            ExerciseSets.RemoveAt(ExerciseSets.FindIndex(es => es.Id == id));
            _navManager.NavigateTo("workouts");
        }

        public async Task<List<ExerciseSet>> GetExerciseSets(int twId)
        {
            var result = await _http.GetFromJsonAsync<List<ExerciseSet>>($"api/ExerciseSets/GetExerciseSets/{twId}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Exercise> GetSingleExerciseSet(int id)
        {
            var result = await _http.GetFromJsonAsync<Exercise>($"api/ExerciseSets/GetExerciseSet/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("ExerciseSet not found");
        }

        public async Task UpdateExerciseSet(ExerciseSet es)
        {
            var result = await _http.PutAsJsonAsync($"api/ExerciseSets/{es.Id}", es);
            var response = await result.Content.ReadFromJsonAsync<ExerciseSet>();
            // TODO: null check
            int index = ExerciseSets.FindIndex(e => e.Id == es.Id);
            if (index != -1)
                ExerciseSets[index] = es;           
        }

        public async Task CreateExerciseSetRange(Workout w, TrackedWorkout tw)
        {
            List<ExerciseSet> list = new List<ExerciseSet>();
            foreach (var item in w.Exercises)
            {
                for (int i = 0; i < item.DefaultNumberOfSets; i++)
                {
                    list.Add(new ExerciseSet
                    {
                        Weight = null,
                        Reps = null,
                        ExerciseId = item.Id,
                        TrackedWorkoutId = tw.Id,
                    });
                }
            }
            var result = await _http.PostAsJsonAsync($"api/ExerciseSets/range", list);
            var response = await result.Content.ReadFromJsonAsync<List<ExerciseSet>>();
            ExerciseSets = response;
        }
    }
}
