using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.WorkoutService
{
    public interface IWorkoutService
    {
        List<Workout> Workouts { get; set; }

        Task GetWorkouts();
        Task<Workout> GetSingleWorkout(int id);
        Task CreateWorkout(Workout workout);
        Task UpdateWorkout(Workout workout, bool fromForm);
        Task DeleteWorkout(int id);

        //TODO: get excercises
    }
}
