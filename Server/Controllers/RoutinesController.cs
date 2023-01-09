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
    public class RoutinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoutinesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Routine>>> GetRoutines()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Routines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Routine>> GetSingleRoutine(int id)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Routines.FirstOrDefault(r => r.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<Routine>> CreateRoutine(Routine routine)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            routine.ApplicationUserId = user.Id;
            _context.Routines.Add(routine);
            await _context.SaveChangesAsync();

            return Ok(routine);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Routine>> UpdateRoutine(Routine routine, int id)
        {
            var dbRoutine = await _context.Routines.FirstOrDefaultAsync(r => r.Id == id);
            if (dbRoutine == null)
            {
                return NotFound("Routine Not Found");
            }
            dbRoutine.Name = routine.Name;

            await _context.SaveChangesAsync();

            return Ok(dbRoutine);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoutine(int id)
        {
            var dbRoutine = await _context.Routines.FirstOrDefaultAsync(r => r.Id == id);
            if (dbRoutine == null)
            {
                return NotFound("Routine Not Found");
            }

            _context.Routines.Remove(dbRoutine);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
