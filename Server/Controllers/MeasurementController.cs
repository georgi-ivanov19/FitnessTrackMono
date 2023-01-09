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
    public class MeasurementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MeasurementController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Measurement>>> GetMeasurements()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Measurements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetSingleMeasurement(int id)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Measurements.FirstOrDefault(m => m.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<Measurement>> CreateMeasurement(Measurement measurement)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            measurement.ApplicationUserId = user.Id;
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();

            return Ok(measurement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Measurement>> UpdateMeasurement(Measurement measurement, int id)
        {
            var dbMeasurement = await _context.Measurements.FirstOrDefaultAsync(m => m.Id == id);
            if (dbMeasurement == null)
            {
                return NotFound("Measurement Not Found");
            }
            dbMeasurement.Value = measurement.Value;
            dbMeasurement.Date = measurement.Date;
            dbMeasurement.Type = measurement.Type;
            dbMeasurement.Unit = measurement.Unit;

            await _context.SaveChangesAsync();

            return Ok(dbMeasurement);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMeasurement(int id)
        {
            var dbMeasurement = await _context.Measurements.FirstOrDefaultAsync(m => m.Id == id);
            if (dbMeasurement == null)
            {
                return NotFound("Measurement Not Found");
            }

            _context.Measurements.Remove(dbMeasurement);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
