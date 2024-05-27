using GameplanAPI.Features.Season;
using Microsoft.EntityFrameworkCore;

namespace GameplanAPI.Shared.Database.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Season> Seasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
