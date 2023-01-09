using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public int RoutineId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
