using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.ExerciseSetService
{
    public interface IExerciseSetService
    {
        List<ExerciseSet> ExerciseSets { get; set; }

        Task GetExerciseSets(int exId);
        Task<Exercise> GetSingleExerciseSet(int id);
        Task CreateExerciseSet(ExerciseSet es);
        Task UpdateExerciseSet(ExerciseSet es);
        Task DeleteExerciseSet(int id);
    }
}
