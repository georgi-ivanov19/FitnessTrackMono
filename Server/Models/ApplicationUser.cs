using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace FitnessTrackMono.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Measurement> measurements { get; set; } = new List<Measurement>();
        public List<Meal> meals { get; set; } = new List<Meal>();
    }
}