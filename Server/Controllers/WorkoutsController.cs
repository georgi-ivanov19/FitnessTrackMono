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
    public class WorkoutsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public WorkoutsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Workout>>> GetWorkouts(string userId)
        {
            if (userId == null)
            {
                return NotFound("UserId is a required query parameter");
            }
            var workouts = await _context.Workouts.Where(w => w.ApplicationUserId == userId).ToListAsync();
            return Ok(workouts);
        }

        [HttpGet("GetWorkout/{id}")]
        public async Task<ActionResult<Workout>> GetSingleWorkout(int id)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
            {
                return NotFound("Workout not found");
            }
            return Ok(workout);
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> CreateWorkout(Workout workout)
        {
            // var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            // if (user == null)
            // {
            //     return NotFound("User not found");
            // }
            // workout.ApplicationUserId = user.Id;
            // _context.Workouts.Add(workout);
            // await _context.SaveChangesAsync();

            // return Ok(workout);
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return Ok(workout);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Workout>> UpdateWorkout(Workout workout, int id)
        {
            var dbWorkout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (dbWorkout == null)
            {
                return NotFound("Workout Not Found");
            }
            dbWorkout.Name = workout.Name;
            dbWorkout.DayOfWeek = workout.DayOfWeek;
            dbWorkout.DateLastCompleted = workout.DateLastCompleted;
            await _context.SaveChangesAsync();

            return Ok(dbWorkout);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkout(int id)
        {
            var dbWorkout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (dbWorkout == null)
            {
                return NotFound("Workout Not Found");
            }

            _context.Workouts.Remove(dbWorkout);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}


