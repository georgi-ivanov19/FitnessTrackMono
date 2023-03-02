using System.Security.Claims;
using FitnessTrackMono.Server.Data;
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
    public class ExerciseSetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExerciseSetsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("GetExerciseSets/{id}")]
        public async Task<ActionResult<List<ExerciseSet>>> GetExerciseSetsForExercise(int id)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound("User not found");
            }

            var tw = await _context.TrackedWorkouts.FirstOrDefaultAsync(e => e.Id == id);
            if (tw == null)
            {
                return NotFound("Workout not found");
            }
            return Ok(tw.ExerciseSetsCompleted);
        }

        [HttpGet("GetExerciseSet/{id}")]
        public async Task<ActionResult<ExerciseSet>> GetSingleExerciseSet(int id)
        {
            var exerciseSet = await _context.ExerciseSets.FirstOrDefaultAsync(e => e.Id == id);
            if (exerciseSet == null)
            {
                return NotFound("Set not found");
            }
            return Ok(exerciseSet);
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseSet>> CreateExerciseSet(ExerciseSet exerciseSet)
        {
            _context.ExerciseSets.Add(exerciseSet);
            await _context.SaveChangesAsync();

            return Ok(exerciseSet);
        }

        [HttpPost("range")]
        public async Task<ActionResult<ExerciseSet>> CreateExerciseSetRange(List<ExerciseSet> exerciseSets)
        {
            _context.ExerciseSets.AddRange(exerciseSets);
            await _context.SaveChangesAsync();

            return Ok(exerciseSets);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ExerciseSet>> UpdateExerciseSet(ExerciseSet exerciseSet, int id)
        {
            var dbExerciseSet = await _context.ExerciseSets.FirstOrDefaultAsync(e => e.Id == id);
            if (dbExerciseSet == null)
            {
                return NotFound("Workout Not Found");
            }
            dbExerciseSet.Reps = exerciseSet.Reps;
            dbExerciseSet.Weight = exerciseSet.Weight;
            dbExerciseSet.IsWarmup = exerciseSet.IsWarmup;
            dbExerciseSet.ExerciseId = exerciseSet.ExerciseId;
            dbExerciseSet.ExerciseName = exerciseSet.ExerciseName;
            dbExerciseSet.IsComplete = exerciseSet.IsComplete;
            await _context.SaveChangesAsync();

            return Ok(dbExerciseSet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExerciseSet(int id)
        {
            var dbExerciseSet = await _context.ExerciseSets.FirstOrDefaultAsync(ex => ex.Id == id);
            if (dbExerciseSet == null)
            {
                return NotFound("Exercise Not Found");
            }

            _context.ExerciseSets.Remove(dbExerciseSet);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
