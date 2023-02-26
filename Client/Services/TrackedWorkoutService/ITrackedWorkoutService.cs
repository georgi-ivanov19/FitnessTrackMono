using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.TrackedWorkoutService
{
    public interface ITrackedWorkoutService
    {
        List<TrackedWorkout> TrackedWorkouts { get; set; }
        Task<List<TrackedWorkout>> GetCompletedTrackedWorkouts(int parentWorkoutId);
        Task<TrackedWorkout> StartWorkout(Workout workout);
        Task<TrackedWorkout> GetSingleWorkout(int id);
        Task<TrackedWorkout> GetLatestCompleted(int parentWorkoutId);
        Task UpdateTrackedWorkout(TrackedWorkout workout, bool finish = false);
    }
}
