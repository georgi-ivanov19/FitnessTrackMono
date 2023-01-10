using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class ExerciseSet
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int Value { get; set; }
        public bool IsWarmup { get; set; }

    }
}
