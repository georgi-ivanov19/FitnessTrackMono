using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackMono.Shared.Models
{
    public class Routine
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
