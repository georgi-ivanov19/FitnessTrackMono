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
            var user = await _context.Users.Include(u => u.Meals).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Meals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetSingleMeal(int id)
        {
            var user = await _context.Users.Include(u => u.Meals).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Meals.FirstOrDefault(m => m.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> CreateMeal(Meal meal)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            // TODO:
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

        [HttpGet("GetAverages")]
        public async Task<ActionResult<List<AverageResults>>> GetAverages([FromQuery] DateTime date)
        {
            var user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null)
            {
                return NotFound();
            }

            var meals = _context.Meals.Where(m => m.ApplicationUserId == user.Id && m.Date >= date.AddDays(-14) && m.Date <= date).ToList();


            return CalculateAverages(date, meals);
        }

        private List<AverageResults> CalculateAverages(DateTime date, List<Meal> meals)
        {
            var currentWeekMeals = meals.Where(m => m.Date >= date.AddDays(-7)).ToList();
            var previousWeekMeals = meals.Where(m => m.Date < date.AddDays(-7)).ToList();


            double[] averageCals = new double[2];
            double[] averageProtein = new double[2];
            double[] averageCarbs = new double[2];
            double[] averageFats = new double[2];

            if (currentWeekMeals.Any())
            {
                var currentTotals = new MealMacros(
                    currentWeekMeals.Sum(m => m.TotalCalories),
                    currentWeekMeals.Sum(m => m.Protein),
                    currentWeekMeals.Sum(m => m.Carbohydrates),
                    currentWeekMeals.Sum(m => m.Fats));

                averageCals[0] = currentTotals.Calories / 7;
                averageProtein[0] = currentTotals.Protein / 7;
                averageCarbs[0] = currentTotals.Carbs / 7;
                averageFats[0] = currentTotals.Fats / 7;
            }

            if (previousWeekMeals.Any())
            {
                var previousTotals = new MealMacros(
                previousWeekMeals.Sum(m => m.TotalCalories),
                previousWeekMeals.Sum(m => m.Protein),
                previousWeekMeals.Sum(m => m.Carbohydrates),
                 previousWeekMeals.Sum(m => m.Fats));

                averageCals[1] = previousTotals.Calories / 7;
                averageProtein[1] = previousTotals.Protein / 7;
                averageCarbs[1] = previousTotals.Carbs / 7;
                averageFats[1] = previousTotals.Fats / 7;
            }

            return new List<AverageResults> {
                new AverageResults(averageCals[0],0, averageCals[1]),
                new AverageResults(averageProtein[0],0, averageProtein[1]),
                new AverageResults(averageCarbs[0],0, averageCarbs[1]),
                new AverageResults(averageFats[0],0, averageFats[1])
            };
        }
    }
}
