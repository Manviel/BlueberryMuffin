using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data.Seeding
{
    public class HotelConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Courtleigh Hotel & Suites The", Address = "Kingston", CountryId = 1, Rating = 4.5 },
                new Hotel { Id = 2, Name = "Hyatt Place New York City", Address = "New York", CountryId = 2, Rating = 5 },
                new Hotel { Id = 3, Name = "ibis Lviv Center", Address = "Lviv", CountryId = 3, Rating = 3.1 }
            );
        }
    }
}
