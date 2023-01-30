using FitnessTrackMono.Server.Data;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessTrackMono.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackedWorkoutsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TrackedWorkoutsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrackedWorkout>>> GetTrackedWorkouts(int id)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound("User not found");
            }

            var workout = _context.Workouts.Find(id);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }
            return Ok(workout.TrackedWorkouts);
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> CreateTrackedWorkout(TrackedWorkout workout)
        {
            _context.TrackedWorkouts.Add(workout);

            await _context.SaveChangesAsync();

            return Ok(workout);
        }

        [HttpGet("GetWorkout/{id}")]
        public async Task<ActionResult<TrackedWorkout>> GetSingleWorkout(int id)
        {
            var workout = await _context.TrackedWorkouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }
            return Ok(workout);
        }

        [HttpGet("GetLatestCompleted/{id}")]
        public async Task<ActionResult<TrackedWorkout>> GetLatestCompleted(int id)
        {
            var workout = await _context.TrackedWorkouts.Where(w => w.ParentWorkoutId == id && w.IsCompleted).OrderByDescending(w => w.EndTime).FirstOrDefaultAsync(w => w.ParentWorkoutId == id);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }
            return Ok(workout);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Workout>> UpdateWorkout(TrackedWorkout workout, int id)
        {
            var dbWorkout = await _context.TrackedWorkouts.FirstOrDefaultAsync(w => w.Id == id);
            if (dbWorkout == null)
            {
                return NotFound("Workout Not Found");
            }
            dbWorkout.TotalVolume = workout.TotalVolume;
            dbWorkout.IsCompleted = workout.IsCompleted;
            dbWorkout.StartTime = workout.StartTime;
            dbWorkout.ParentWorkoutId = workout.ParentWorkoutId;
            dbWorkout.ExerciseSetsCompleted = workout.ExerciseSetsCompleted;
            dbWorkout.EndTime = workout.EndTime;
            await _context.SaveChangesAsync();

            return Ok(dbWorkout);
        }
    }
}
