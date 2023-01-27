using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace FitnessTrackMono.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = String.Empty;
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public List<Workout> Workouts { get; set; } = new List<Workout>();
    }
}