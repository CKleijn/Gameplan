using GameplanAPI.Features.Competition;
using GameplanAPI.Features.Season;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
