using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data
{
    public class BlueberryDbContext : DbContext
    {
        public BlueberryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Jamaica", CodeName = "JM" },
                new Country { Id = 2, Name = "United States", CodeName = "US" },
                new Country { Id = 3, Name = "Ukraine", CodeName = "UA" }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, Name = "Courtleigh Hotel & Suites The", Address = "Kingston", CountryId = 1, Rating = 4.5 },
                new Hotel { Id = 2, Name = "Hyatt Place New York City", Address = "New York", CountryId = 2, Rating = 5 },
                new Hotel { Id = 3, Name = "ibis Lviv Center", Address = "Lviv", CountryId = 3, Rating = 3.1 }
            );
        }
    }
}
