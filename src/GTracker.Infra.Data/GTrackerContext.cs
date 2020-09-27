using GTracker.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GTracker.Infra.Data
{
    public class GTrackerContext : DbContext
    {
        public GTrackerContext(DbContextOptions<GTrackerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}