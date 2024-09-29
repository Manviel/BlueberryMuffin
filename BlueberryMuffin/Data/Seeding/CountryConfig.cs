using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Data.Seeding
{
    public class CountryConfig : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new Country { Id = 1, Name = "Jamaica", CodeName = "JM" },
                new Country { Id = 2, Name = "United States", CodeName = "US" },
                new Country { Id = 3, Name = "Ukraine", CodeName = "UA" }
            );
        }
    }
}
