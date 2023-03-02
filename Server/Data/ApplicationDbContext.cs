using Duende.IdentityServer.EntityFramework.Options;
using FitnessTrackMono.Server.Models;
using FitnessTrackMono.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
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

            builder.Entity<Exercise>().HasMany(m => m.ExerciseSets).WithOne().OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Exercise>().Navigation(e => e.ExerciseSets);

            builder.Entity<TrackedWorkout>().HasMany(e => e.ExerciseSetsCompleted).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TrackedWorkout>().Navigation(e => e.ExerciseSetsCompleted).AutoInclude();          
        }

        public DbSet<Measurement> Measurements => Set<Measurement>();
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<Workout> Workouts => Set<Workout>();
        public DbSet<TrackedWorkout> TrackedWorkouts => Set<TrackedWorkout>();
        public DbSet<Exercise> Exercises => Set<Exercise>();
        public DbSet<ExerciseSet> ExerciseSets => Set<ExerciseSet>();
    }
}