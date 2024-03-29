﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class ExerciseSet
    {
        public int Id { get; set; }
        public int? ExerciseId { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
        public int? Reps { get; set; }
        public double? Weight { get; set; }
        public bool IsWarmup { get; set; }
        public bool IsComplete { get; set; }
        public int TrackedWorkoutId { get; set; }
    }
}
