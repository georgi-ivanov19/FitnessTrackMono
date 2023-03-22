using System.Security.Claims;
using FitnessTrackMono.Server.Data;
using FitnessTrackMono.Server.Data.Migrations;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackMono.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExercisesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
        }

        [HttpGet("GetExercises/{id}")]
        public async Task<ActionResult<List<Exercise>>> GetExercisesForWorkout(int id)
        {
            // var user = await _context.Users.Include(u => u.Workouts).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            // if (user == null)
            // {
            //     return NotFound("User not found");
            // }

            // var workout = user.Workouts.FirstOrDefault(w => w.Id == id);
            // if (workout == null)
            // {
            //     return NotFound("Workout not found");
            // }
            // return Ok(workout.Exercises);
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }
            return Ok(workout.Exercises);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            if (exercise == null)
            {
                return NotFound("Exercise not found");
            }
            return Ok(exercise);
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return Ok(exercise);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Exercise>> UpdateExercise(Exercise exercise, int id)
        {
            var dbExercise = await _context.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
            if (dbExercise == null)
            {
                return NotFound("Exercise Not Found");
            }
            dbExercise.WorkoutId = exercise.WorkoutId;
            dbExercise.DefaultNumberOfSets = exercise.DefaultNumberOfSets;
            dbExercise.Name = exercise.Name;
            dbExercise.TargetMuscle = exercise.TargetMuscle;
            await _context.SaveChangesAsync();

            return Ok(dbExercise);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExercise(int id)
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
