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
    public class MealController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MealController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Meal>>> GetMeals()
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Meals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetSingleMeal(int id)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Meals.FirstOrDefault(m => m.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> CreateMeal(Meal meal)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            meal.ApplicationUserId = user.Id;
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return Ok(meal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Meal>> UpdateMeal(Meal meal, int id)
        {
            var dbMeal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);
            if (dbMeal == null)
            {
                return NotFound("Meal Not Found");
            }
            dbMeal.Category = meal.Category;
            dbMeal.Date = meal.Date;
            dbMeal.TotalCalories = meal.TotalCalories;
            dbMeal.Protein = meal.Protein;
            dbMeal.Fats = meal.Fats;
            dbMeal.Carbohydrates = meal.Carbohydrates;

            await _context.SaveChangesAsync();

            return Ok(dbMeal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMeal(int id)
        {
            var dbMeal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id);
            if (dbMeal == null)
            {
                return NotFound("Measurement Not Found");
            }

            _context.Meals.Remove(dbMeal);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
