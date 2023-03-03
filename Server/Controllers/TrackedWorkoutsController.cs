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

        public TrackedWorkoutsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrackedWorkout>>> GetTrackedWorkouts(int id)
        {
            var user = await _context.Users.Include(u => u.Workouts).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound("User not found");
            }

            var workout = user.Workouts.Find(w => w.Id == id);
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
            var user = await _context.Users.Include(u => u.Workouts).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var workout = user.Workouts.Find(w => w.Id == id);
            var latestCompleted = workout.TrackedWorkouts.Where(w => w.IsCompleted).OrderByDescending(w => w.EndTime).First();
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
            dbWorkout.WorkoutId = workout.WorkoutId;
            dbWorkout.ExerciseSetsCompleted = workout.ExerciseSetsCompleted;
            dbWorkout.EndTime = workout.EndTime;
            dbWorkout.Notes = workout.Notes;
            await _context.SaveChangesAsync();

            return Ok(dbWorkout);
        }

        [HttpGet("GetAverages")]
        public async Task<ActionResult<Dictionary<int, List<AverageResults>>>> GetAverages([FromQuery] DateTime date)
        {
            var user = await _context.Users.Include(u => u.Workouts).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = new Dictionary<int, List<AverageResults>>();
            foreach (var workout in user.Workouts)
            {
                // all complete tracked workouts for the past 30 days
                var trackedWorkouts = _context.TrackedWorkouts.Where(w => w.WorkoutId == workout.Id && w.IsCompleted && w.EndTime >= date.AddDays(-60) && w.EndTime <= date).ToList();
                result.Add(workout.Id, CalculateAverages(date, trackedWorkouts));
            }

            return result;
        }

        private List<AverageResults> CalculateAverages(DateTime date, List<TrackedWorkout> trackedWorkouts)
        {
            var currentWorkouts = trackedWorkouts.Where(m => m.EndTime >= date.AddDays(-30)).ToList();
            var previousWorkouts = trackedWorkouts.Where(m => m.EndTime < date.AddDays(-30)).ToList();


            double? averageCurrentVolume = null;
            double? averageCurrentDuration = null;

            double? averagePrevVolume = null;
            double? averagePrevDuration = null;

            if (currentWorkouts.Any())
            {
                averageCurrentVolume = currentWorkouts.Sum(w => w.TotalVolume) / currentWorkouts.Count;
                TimeSpan totalTimeSpan = TimeSpan.Zero;
                foreach (var w in currentWorkouts)
                {
                    var duration = w.EndTime - w.StartTime;
                    totalTimeSpan += (TimeSpan)duration;
                }
                averageCurrentDuration = currentWorkouts.Count != 0 ? totalTimeSpan.TotalMicroseconds / currentWorkouts.Count : null;
            }

            if (previousWorkouts.Any())
            {
                averagePrevVolume = previousWorkouts.Sum(w => w.TotalVolume) / previousWorkouts.Count;
                TimeSpan totalTimeSpan = TimeSpan.Zero;
                foreach (var w in previousWorkouts)
                {
                    var duration = w.EndTime - w.StartTime;
                    totalTimeSpan += (TimeSpan)duration;
                }
               
                averagePrevDuration = previousWorkouts.Count != 0 ? totalTimeSpan.TotalMicroseconds / previousWorkouts.Count : null; 
            }
            
            return new List<AverageResults> {
                new AverageResults(averageCurrentVolume, currentWorkouts.Count, averagePrevVolume),
                new AverageResults(averageCurrentDuration, currentWorkouts.Count, averagePrevDuration),
            };
        }
    }
}
