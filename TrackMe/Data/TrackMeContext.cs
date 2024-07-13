using Microsoft.EntityFrameworkCore;
using TrackMe.Models.Entities;

namespace TrackMe.Data
{
    public class TrackMeContext : DbContext
    {
        public TrackMeContext(DbContextOptions<TrackMeContext> options) : base(options) { }

        public DbSet<Carrier> Carriers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrier>().ToTable("Carriers");

            base.OnModelCreating(modelBuilder);
        }
    }
}
