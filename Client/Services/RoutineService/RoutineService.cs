using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace FitnessTrackMono.Client.Services.RoutineService
{


  public class RoutineService : IRoutineService
  {
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
      routine.Workouts = new List<Workout>();
      var result = await _http.PostAsJsonAsync("api/routines", routine);
      var response = await result.Content.ReadFromJsonAsync<Routine>();
      // TODO: null check
      Routines.Add(response);
      _navManager.NavigateTo("routines");
    }

    public async Task DeleteRoutine(int id)
    {
      await _http.DeleteAsync($"api/routines/{id}");
      Routines.RemoveAt(Routines.FindIndex(r => r.Id == id));
      _navManager.NavigateTo("routines");
    }

    public async Task GetRoutines()
    {
      var result = await _http.GetFromJsonAsync<List<Routine>>("api/routines");
      if (result != null)
      {
        this.Routines = result;
      }
    }

    public async Task<Routine> GetSingleRoutine(int id)
    {
      var result = await _http.GetFromJsonAsync<Routine>($"api/routines/{id}");
      if (result != null)
      {
        return result;
      }
      throw new Exception("Routine not found");
    }

    public async Task UpdateRoutine(Routine routine)
    {
      var result = await _http.PutAsJsonAsync($"api/routines/{routine.Id}", routine);
      var response = await result.Content.ReadFromJsonAsync<Routine>();
      // TODO: null check
      int index = Routines.FindIndex(r => r.Id == routine.Id);
      if (index != -1)
        Routines[index] = routine;
      _navManager.NavigateTo("routines");
    }

    public List<Workout> GetWorkouts(int routineId)
    {
      return Routines[routineId].Workouts;
    }
  }
}
