using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace FitnessTrackMono.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public List<Routine> Routines { get; set; } = new List<Routine>();
    }
}