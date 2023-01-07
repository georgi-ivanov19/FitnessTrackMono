using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using System.Net.Http.Json;

namespace FitnessTrackMono.Client.Services.MealService
{
    public class MealService : IMealService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navManager;
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public MealService(HttpClient http, NavigationManager navManager)
        {
            _http = http;
            _navManager = navManager;
        }
        public async Task GetMeals()
        {
            var result = await _http.GetFromJsonAsync<List<Meal>>("api/meal");
            if (result != null)
            {
                this.Meals = result;
            }
        }

        public async Task CreateMeal(Meal meal)
        {
            var result = await _http.PostAsJsonAsync("api/meal", meal);
            var response = await result.Content.ReadFromJsonAsync<Meal>();
            // TODO: null check
            Meals.Add(response);
            _navManager.NavigateTo("meals");
        }

        public async Task DeleteMeal(int id)
        {
            await _http.DeleteAsync($"api/meal/{id}");
            Meals.RemoveAt(Meals.FindIndex(m => m.Id == id));
            _navManager.NavigateTo("meals");
        }


        public async Task<Meal> GetSingleMeal(int id)
        {
            var result = await _http.GetFromJsonAsync<Meal>($"api/meal/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Meal not found");
        }

        public async Task UpdateMeal(Meal meal)
        {
            var result = await _http.PutAsJsonAsync($"api/meal/{meal.Id}", meal);
            var response = await result.Content.ReadFromJsonAsync<Meal>();
            // TODO: null check
            int index = Meals.FindIndex(m => m.Id == meal.Id);
            if (index != -1)
                Meals[index] = meal;
            _navManager.NavigateTo("meals");
        }
    }
}
