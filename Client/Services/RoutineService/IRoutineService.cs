using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.RoutineService
{
    public interface IRoutineService
    {
        List<Routine> Routines { get; set; }
        // TODO: a list of workouts

        Task GetRoutines();
        Task<Meal> GetSingleRoutine(int id);
        Task CreateRoutine(Meal meal);
        Task UpdateRoutine(Meal meal);
        Task DeleteRoutine(int id);
    }
}
