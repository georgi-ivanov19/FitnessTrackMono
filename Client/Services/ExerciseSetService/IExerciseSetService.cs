using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.ExerciseSetService
{
    public interface IExerciseSetService
    {
        List<ExerciseSet> ExerciseSets { get; set; }

        Task CreateExerciseSetRange(Workout w, TrackedWorkout tw);
        Task<ExerciseSet> UpdateExerciseSet(ExerciseSet set);
    }
}
