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

      var ex = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id);
      if (ex == null)
      {
        return NotFound("Exercise not found");
      }
      return Ok(ex.ExerciseSets);
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

    [HttpPut("{id}")]
    public async Task<ActionResult<ExerciseSet>> UpdateExerciseSet(ExerciseSet exerciseSet, int id)
    {
      var dbExerciseSet = await _context.ExerciseSets.FirstOrDefaultAsync(e => e.Id == id);
      if (dbExerciseSet == null)
      {
        return NotFound("Workout Not Found");
      }
      dbExerciseSet.Value = exerciseSet.Value;
      dbExerciseSet.Unit = dbExerciseSet.Unit;
      dbExerciseSet.IsWarmup = dbExerciseSet.IsWarmup;
      dbExerciseSet.ExerciseId = dbExerciseSet.ExerciseId;
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
