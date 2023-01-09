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
            builder.Entity<ApplicationUser>().Navigation(e => e.measurements).AutoInclude();
            builder.Entity<ApplicationUser>().Navigation(e => e.meals).AutoInclude();
            builder.Entity<ApplicationUser>().Navigation(e => e.rountines).AutoInclude();
        }

        public DbSet<Measurement> Measurements => Set<Measurement>();
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<Routine> Routines => Set<Routine>();
    }
}