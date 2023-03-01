using System.Security.Claims;
using FitnessTrackMono.Server.Data;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var user = await _context.Users.Include(u => u.Measurements).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Measurements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetSingleMeasurement(int id)
        {
            var user = await _context.Users.Include(u => u.Measurements).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Measurements.FirstOrDefault(m => m.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<Measurement>> CreateMeasurement(Measurement measurement)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
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

        [HttpGet("GetAverages")]
        public async Task<ActionResult<List<AverageResults>>> GetLatestCompleted([FromQuery] DateTime date)
        {
            // 7 days moving average from date for each measurement
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            if (user == null)
            {
                return NotFound();
            }
            var measurements = _context.Measurements.Where(m => m.ApplicationUserId == user.Id && m.Date >= date.AddDays(-14) && m.Date <= date).ToList();
            var weightMeasurements = new List<Measurement>();
            var waistMeasurements = new List<Measurement>();
            var bfMeasurements = new List<Measurement>();
            foreach (var measurement in measurements)
            {
                switch (measurement.Type)
                {
                    case "Weight":
                        weightMeasurements.Add(measurement);
                        break;
                    case "Waist":
                        waistMeasurements.Add(measurement);
                        break;
                    case "Body fat": 
                        bfMeasurements.Add(measurement);
                        break;
                }
            }
            return new List<AverageResults>
            {
                CalculateAverages(date, weightMeasurements),
                CalculateAverages(date, waistMeasurements),
                CalculateAverages(date, bfMeasurements)
            };
        }

        private AverageResults CalculateAverages(DateTime date, List<Measurement> measurements)
        {
            var currentMeasurements = measurements.Where(m => m.Date >= date.AddDays(-7));
            var previousMeasurements = measurements.Where(m => m.Date < date.AddDays(-7));
            double? currentAverage = null;
            double? previousAverage = null;
            int currentCount = 0;
            if(currentMeasurements.Any())
            {
                currentAverage = currentMeasurements.Average(m => m.Value);
                currentCount = currentMeasurements.Count();
            }
            if(previousMeasurements.Any())
            {
                previousAverage = previousMeasurements.Average(m => m.Value);
            }
            return new AverageResults(currentAverage, currentCount, previousAverage);
        }
    }
}
