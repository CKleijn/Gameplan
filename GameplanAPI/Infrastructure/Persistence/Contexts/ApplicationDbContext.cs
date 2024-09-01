using GameplanAPI.Features.Match;
using GameplanAPI.Features.Season;
using GameplanAPI.Features.User;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Match>()
                .HasOne(m => m.Season)
                .WithMany(s => s.Matches)
                .HasForeignKey(m => m.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Season>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .HasPrincipalKey(u => u.UID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
