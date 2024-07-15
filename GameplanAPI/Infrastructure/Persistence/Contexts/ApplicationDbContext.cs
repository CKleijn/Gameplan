using GameplanAPI.Features.Match;
using GameplanAPI.Features.Season;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Match>()
                .HasOne<Season>()
                .WithMany()
                .HasForeignKey(m => m.SeasonId);
        }
    }
}
