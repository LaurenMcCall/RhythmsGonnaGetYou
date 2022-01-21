using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{
    class RhythmsGonnaGetYouContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=BandsAndAlbums");
        }
    }
}


