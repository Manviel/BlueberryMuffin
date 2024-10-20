using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data.Seeding
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel { Id = 1, Name = "Courtleigh Hotel & Suites The", Address = "Kingston", SurveyId = 1, Rating = 4.5 },
                new Hotel { Id = 2, Name = "Hyatt Place New York City", Address = "New York", SurveyId = 2, Rating = 5 },
                new Hotel { Id = 3, Name = "ibis Lviv Center", Address = "Lviv", SurveyId = 3, Rating = 3.1 }
            );
        }
    }
}
