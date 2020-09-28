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
            modelBuilder.ApplyConfiguration(new FriendMap());
            modelBuilder.ApplyConfiguration(new GameMap());
            modelBuilder.ApplyConfiguration(new LoanMap());
            modelBuilder.ApplyConfiguration(new LoanGameMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}