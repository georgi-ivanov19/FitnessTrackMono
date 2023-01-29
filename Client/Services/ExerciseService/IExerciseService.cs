﻿using FitnessTrackMono.Shared.Models;

namespace FitnessTrackMono.Client.Services.ExerciseService
{
    public interface IExerciseService
    {
        List<Exercise> Exercises { get; set; }

        Task GetExercises(int workoutId);
        Task<Exercise> GetSingleExercise(int id);
        Task CreateExercise(Exercise ex);

        Task UpdateExercise(Exercise ex);
        Task DeleteExercise(int id);

        //TODO: GetSets
    }
}
