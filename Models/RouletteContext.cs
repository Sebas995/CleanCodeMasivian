using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class RouletteContext : DbContext
    {
        public RouletteContext(DbContextOptions<RouletteContext> options):base(options)
        {
        }

        public DbSet<RouletteModel> Roulettes { get; set; }
        public DbSet<BetModel> RoulettesBets { get; set; }
    }
}
