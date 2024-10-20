using BlueberryMuffin.Data.Seeding;
using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data
{
    public class BlueberryDbContext : IdentityDbContext<ApiUser>
    {
        public BlueberryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new SurveyConfig());
            modelBuilder.ApplyConfiguration(new HotelConfig());
        }
    }
}
