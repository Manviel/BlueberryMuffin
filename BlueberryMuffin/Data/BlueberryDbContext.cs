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
    }
}
