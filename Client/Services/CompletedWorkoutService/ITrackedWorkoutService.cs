using FitnessTrackMono.Client.Pages;
using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.TrackedWorkoutService
{
    public interface ITrackedWorkoutService
    {
        List<TrackedWorkout> TrackedWorkouts { get; set; }
        public Task StartWorkout(Workout workout);
        public Task FinishWorkout(TrackedWorkout workout);
        Task<TrackedWorkout> GetSingleWorkout(int id);
    }
}
