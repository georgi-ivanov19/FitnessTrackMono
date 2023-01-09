using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.RoutineService
{
    public interface IRoutineService
    {
        List<Routine> Routines { get; set; }
        // TODO: a list of workouts

        Task GetRoutines();
        Task<Routine> GetSingleRoutine(int id);
        Task CreateRoutine(Routine meal);
        Task UpdateRoutine(Routine meal);
        Task DeleteRoutine(int id);
    }
}
