using FitnessTrackMono.Server.Data;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessTrackMono.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardResults>> GetAverages([FromQuery] string userId, [FromQuery] DateTime date)
        {
            var workoutsResponse = await GetWorkoutsAverages(userId, date);
            var workoutsAverages = workoutsResponse.Value;

            var measurementsResponse = await GetMeasurementsAverages(userId, date);
            var measurementsAverages = measurementsResponse.Value;

            var mealsResponse = await GetMealsAverages(userId, date);
            var mealsAverages = mealsResponse.Value;

            return new DashboardResults(measurementsAverages, mealsAverages, workoutsAverages);
        }

        private async Task<ActionResult<Dictionary<int, List<AverageResults>>>> GetWorkoutsAverages([FromQuery] string userId, [FromQuery] DateTime date)
        {
           // var user = await _context.Users.Include(u => u.Workouts).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userWorkouts = await _context.Workouts.Where(w => w.ApplicationUserId == userId).ToListAsync();
            //if (user == null)
            //{
                //return NotFound("User not found");
            //}
            if (userWorkouts == null || userWorkouts.Count == 0)
            {
                return NotFound("User has no workouts");
            }
            var result = new Dictionary<int, List<AverageResults>>();
            foreach (var workout in userWorkouts)
            {
                // all complete tracked workouts for the past 30 days
                var trackedWorkouts = _context.TrackedWorkouts.Where(w => w.WorkoutId == workout.Id && w.IsCompleted && w.EndTime >= date.AddDays(-60) && w.EndTime <= date).ToList();
                result.Add(workout.Id, CalculateWorkoutsAverages(date, trackedWorkouts));
            }

            return result;
        }

        private List<AverageResults> CalculateWorkoutsAverages(DateTime date, List<TrackedWorkout> trackedWorkouts)
        {
            var currentWorkouts = trackedWorkouts.Where(m => m.EndTime >= date.AddDays(-30)).ToList();
            var previousWorkouts = trackedWorkouts.Where(m => m.EndTime < date.AddDays(-30)).ToList();


            double? averageCurrentVolume = null;
            double? averageCurrentDuration = null;

            double? averagePrevVolume = null;
            double? averagePrevDuration = null;

            if (currentWorkouts.Any())
            {
                averageCurrentVolume = currentWorkouts.Sum(w => w.TotalVolume) / currentWorkouts.Count;
                TimeSpan totalTimeSpan = TimeSpan.Zero;
                foreach (var w in currentWorkouts)
                {
                    var duration = w.EndTime - w.StartTime;
                    totalTimeSpan += (TimeSpan)duration;
                }
                averageCurrentDuration = currentWorkouts.Count != 0 ? totalTimeSpan.TotalMicroseconds / currentWorkouts.Count : null;
            }

            if (previousWorkouts.Any())
            {
                averagePrevVolume = previousWorkouts.Sum(w => w.TotalVolume) / previousWorkouts.Count;
                TimeSpan totalTimeSpan = TimeSpan.Zero;
                foreach (var w in previousWorkouts)
                {
                    var duration = w.EndTime - w.StartTime;
                    totalTimeSpan += (TimeSpan)duration;
                }

                averagePrevDuration = previousWorkouts.Count != 0 ? totalTimeSpan.TotalMicroseconds / previousWorkouts.Count : null;
            }

            return new List<AverageResults> {
                new AverageResults(averageCurrentVolume, currentWorkouts.Count, averagePrevVolume),
                new AverageResults(averageCurrentDuration, currentWorkouts.Count, averagePrevDuration),
            };
        }

        private async Task<ActionResult<List<AverageResults>>> GetMeasurementsAverages([FromQuery] string userId, [FromQuery] DateTime date)
        {
            // 7 days moving average from date for each measurement
            //var user = await _context.Users.Include(u => u.Measurements).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userMeasurements = await _context.Measurements.Where(m => m.ApplicationUserId == userId && m.Date >= date.AddDays(-14) && m.Date <= date).ToListAsync();

            // if (user == null)
            // {
            //     return NotFound();
            // }
            // var measurements = user.Measurements.Where(m => m.Date >= date.AddDays(-14) && m.Date <= date).ToList();
            if (userMeasurements == null || userMeasurements.Count == 0)
            {
                return NotFound("User has no measurements");
            }
            var weightMeasurements = new List<Measurement>();
            var waistMeasurements = new List<Measurement>();
            var bfMeasurements = new List<Measurement>();
            foreach (var measurement in userMeasurements)
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
                CalculateMeasuremetsAverages(date, weightMeasurements),
                CalculateMeasuremetsAverages(date, waistMeasurements),
                CalculateMeasuremetsAverages(date, bfMeasurements)
            };
        }

        private AverageResults CalculateMeasuremetsAverages(DateTime date, List<Measurement> measurements)
        {
            var currentMeasurements = measurements.Where(m => m.Date >= date.AddDays(-7));
            var previousMeasurements = measurements.Where(m => m.Date < date.AddDays(-7));
            double? currentAverage = null;
            double? previousAverage = null;
            int currentCount = 0;
            if (currentMeasurements.Any())
            {
                currentAverage = currentMeasurements.Average(m => m.Value);
                currentCount = currentMeasurements.Count();
            }
            if (previousMeasurements.Any())
            {
                previousAverage = previousMeasurements.Average(m => m.Value);
            }
            return new AverageResults(currentAverage, currentCount, previousAverage);
        }

        private async Task<ActionResult<List<AverageResults>>> GetMealsAverages([FromQuery] string userId, [FromQuery] DateTime date)
        {
            //var user = await _context.Users.Include(u => u.Meals).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userMeals = await _context.Meals.Where(m => m.ApplicationUserId == userId && m.Date >= date.AddDays(-14) && m.Date <= date).ToListAsync();


            // if (user == null)
            // {
            //     return NotFound();
            // }

            // var meals = user.Meals.Where(m => m.Date >= date.AddDays(-14) && m.Date <= date).ToList();
            if (userMeals == null)
                {
                    return NotFound("User has not Meals");
                }

            return CalculateMealsAverages(date, userMeals);
        }

        private List<AverageResults> CalculateMealsAverages(DateTime date, List<Meal> meals)
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
                    currentWeekMeals.Sum(m => (double)m.TotalCalories),
                    currentWeekMeals.Sum(m => (double)m.Protein),
                    currentWeekMeals.Sum(m => (double)m.Carbohydrates),
                    currentWeekMeals.Sum(m => (double)m.Fats));

                averageCals[0] = currentTotals.Calories / 7;
                averageProtein[0] = currentTotals.Protein / 7;
                averageCarbs[0] = currentTotals.Carbs / 7;
                averageFats[0] = currentTotals.Fats / 7;
            }

            if (previousWeekMeals.Any())
            {
                var previousTotals = new MealMacros(
                previousWeekMeals.Sum(m => (double)m.TotalCalories),
                previousWeekMeals.Sum(m => (double)m.Protein),
                previousWeekMeals.Sum(m => (double)m.Carbohydrates),
                previousWeekMeals.Sum(m => (double)m.Fats));

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
