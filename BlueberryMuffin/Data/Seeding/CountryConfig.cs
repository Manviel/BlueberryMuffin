using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Data.Seeding
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country { Id = 1, Name = "Jamaica", CodeName = "JM" },
                new Country { Id = 2, Name = "United States", CodeName = "US" },
                new Country { Id = 3, Name = "Ukraine", CodeName = "UA" }
            );
        }
    }
}
