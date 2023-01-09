using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.WorkoutService
{
    public interface IWorkoutService
    {
        List<Workout> Workouts { get; set; }

        Task GetWorkouts(int routineId);
        Task<Workout> GetSingleWorkout(int id);
        Task CreateWorkout(Workout workout);
        Task UpdateWorkout(Workout workout);
        Task DeleteWorkout(int id);

        //get excercises
    }
}
