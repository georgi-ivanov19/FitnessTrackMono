using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.ExerciseSetService
{
    public interface IExerciseSetService
    {
        List<ExerciseSet> ExerciseSets { get; set; }

        Task<List<ExerciseSet>> GetExerciseSets(int twId);
        Task<Exercise> GetSingleExerciseSet(int id);
        Task CreateExerciseSet(ExerciseSet es);
        Task CreateExerciseSetRange(Workout w, TrackedWorkout tw);
        Task UpdateExerciseSet(ExerciseSet es);
        Task DeleteExerciseSet(int id);
    }
}
