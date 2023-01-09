using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.RoutineService
{
    public interface IRoutineService
    {
        List<Routine> Routines { get; set; }

        Task GetRoutines();
        Task<Routine> GetSingleRoutine(int id);
        Task CreateRoutine(Routine routine);
        Task UpdateRoutine(Routine routine);
        Task DeleteRoutine(int id);
        List<Workout> GetWorkouts(int id);
    }
}
