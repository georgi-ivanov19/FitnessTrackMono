using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class CompletedWorkout
    {
        public int Id { get; set; }
        public Workout ParentWorkout { get; set; } = new Workout();
        public double TotalVolume { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<ExerciseSet> ExerciseSetsCompleted { get; set; }
    }
}
