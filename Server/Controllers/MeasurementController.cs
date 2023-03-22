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
    [Route("api/Measurements")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MeasurementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Measurement>>> GetMeasurements(string applicationUserId)
        {
            if(applicationUserId == null)
            {
                return BadRequest("User ID is a required parameter");
            }
            var measurements = await _context.Measurements.Where(m => m.ApplicationUserId == applicationUserId).ToListAsync();

            return Ok(measurements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetSingleMeasurement(int id)
        {
            var measurement = await _context.Measurements.FirstOrDefaultAsync(m => m.Id == id);
            if (measurement == null)
            {
                return NotFound("Measurement not found");
            }
            return Ok(measurement);
        }

        [HttpPost]
        public async Task<ActionResult<Measurement>> CreateMeasurement(Measurement measurement)
        {
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
