using FitnessTrackMono.Server.Data;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
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

        public TrackedWorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrackedWorkout>>> GetTrackedWorkouts(int id)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
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
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
            {
                return NotFound("Parent Workout not found");
            }

            var completeWorkouts = workout.TrackedWorkouts.Where(w => w.IsCompleted);
            if(!completeWorkouts.Any()){
                return NotFound("No complete workouts found");
            }

            var latestCompleted = completeWorkouts.OrderByDescending(w => w.EndTime).First();
            return Ok(latestCompleted);
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
            dbWorkout.WorkoutId = workout.WorkoutId;
            dbWorkout.ExerciseSetsCompleted = workout.ExerciseSetsCompleted;
            dbWorkout.EndTime = workout.EndTime;
            dbWorkout.Notes = workout.Notes;
            await _context.SaveChangesAsync();

            return Ok(dbWorkout);
        }
    }
}
