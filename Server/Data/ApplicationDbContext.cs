using Azure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FitnessTrackMono.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().HasMany(m => m.Measurements);
            builder.Entity<ApplicationUser>().Navigation(m => m.Measurements);
            builder.Entity<ApplicationUser>().HasMany(m => m.Meals);
            builder.Entity<ApplicationUser>().Navigation(e => e.Meals);
            builder.Entity<ApplicationUser>().HasMany(m => m.Workouts);
            builder.Entity<ApplicationUser>().Navigation(e => e.Workouts);

            builder.Entity<Workout>().HasMany(m => m.Exercises).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Workout>().HasMany(m => m.TrackedWorkouts).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Workout>().Navigation(e => e.Exercises).AutoInclude();
            builder.Entity<Workout>().Navigation(e => e.TrackedWorkouts).AutoInclude();

            builder.Entity<TrackedWorkout>().HasMany(e => e.ExerciseSetsCompleted).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TrackedWorkout>().Navigation(e => e.ExerciseSetsCompleted).AutoInclude();

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            var users = new List<ApplicationUser>();
            var measurements = new List<Measurement>();
            var meals = new List<Meal>();
            var exercises = new List<Exercise>();
            var workouts = new List<Workout>();
            var trackedWorkouts = new List<TrackedWorkout>();
            var exerciseSets = new List<ExerciseSet>();

            for (int i = 0; i <= 10; i++)
            {
                // Generate User
                var userId = Guid.NewGuid().ToString();
                var email = $"user{i}@example.com";
                var user = new ApplicationUser
                {
                    Id = userId,
                    Email = email,
                    NormalizedEmail = email.ToUpper(),
                    UserName = email,
                    NormalizedUserName = email.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "password")
                };

                // Generate measurements and meals
                Random random = new Random();
                for (int j = 1; j <= 14; j++)
                {
                    var meal = new Meal
                    {
                        Id = i * 14 + j,
                        TotalCalories = random.Next(1300, 2000),
                        Protein = random.Next(100, 150),
                        Carbohydrates = random.Next(130, 180),
                        Fats = random.Next(30, 50),
                        Category = "Breakfast",
                        ApplicationUserId = userId,
                        Date = DateTime.Now.AddDays(0 - j)
                    };

                    var measurement = new Measurement
                    {
                        Id = i * 14 + j,
                        Value = random.Next(80, 87),
                        ApplicationUserId = userId,
                        Type = "Weight",
                        Date = DateTime.Now.AddDays(0 - j),
                        Unit = "kg"
                    };
                    measurements.Add(measurement);
                    meals.Add(meal);
                }

                // Generate Workouts
                string[] days = { "Monday", "Wednesday", "Friday" };
                for (int z = 1; z <= 3; z++)
                {
                    var workoutId = i * 3 + z;
                    var workout = new Workout
                    {
                        Id = workoutId,
                        ApplicationUserId = userId,
                        Name = $"Workout{z}",
                        DayOfWeek = days[z - 1],
                        DateLastCompleted = DateTime.Now,
                    };
                    var workoutExercises = new List<Exercise>();

                    for (int x = 1; x <= 3; x++)
                    {
                        var exercise = new Exercise
                        {
                            Id = i * 9 + ((z - 1) * 3) + x,
                            Name = $"Exercise{x}",
                            WorkoutId = workoutId,
                            DefaultNumberOfSets = 3,
                            TargetMuscle = $"Muscle{x}"
                        };
                        workoutExercises.Add(exercise);
                        exercises.Add(exercise);
                    }

                    var trackedWorkout = new TrackedWorkout
                    {
                        Id = workoutId,
                        WorkoutId = workoutId,
                        TotalVolume = 1000,
                        IsCompleted = true,
                        EndTime = DateTime.Now,
                        StartTime = DateTime.Now.AddHours(-2),
                        Notes = $"Notes for TrackedWorkout{workoutId}"
                    };
                    trackedWorkouts.Add(trackedWorkout);

                    foreach(var ex in workoutExercises)
                    {
                        for (int x = 1; x <= 3; x++)
                        {
                            var exerciseSet = new ExerciseSet
                            {
                                Id = ex.Id * 3 + x,
                                ExerciseId = ex.Id,
                                IsComplete = true,
                                IsWarmup = false,
                                Reps = 10,
                                Weight = 10,
                                TrackedWorkoutId = workoutId,
                                ExerciseName = ex.Name
                            };
                            exerciseSets.Add(exerciseSet);
                        }
                    }

                    workouts.Add(workout);
                }

                users.Add(user);

            }
            builder.Entity<Meal>().HasData(meals);
            builder.Entity<Measurement>().HasData(measurements);
            builder.Entity<Exercise>().HasData(exercises);
            builder.Entity<Workout>().HasData(workouts);
            builder.Entity<ApplicationUser>().HasData(users);
            builder.Entity<TrackedWorkout>().HasData(trackedWorkouts);
            builder.Entity<ExerciseSet>().HasData(exerciseSets);
        }

        public DbSet<Measurement> Measurements => Set<Measurement>();
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<Workout> Workouts => Set<Workout>();
        public DbSet<TrackedWorkout> TrackedWorkouts => Set<TrackedWorkout>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();
    }
}