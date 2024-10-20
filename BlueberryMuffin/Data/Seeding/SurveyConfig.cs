using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Data.Seeding
{
    public class SurveyConfig : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasData(
                new Survey { Id = 1, Name = "Jamaica", CodeName = "JM" },
                new Survey { Id = 2, Name = "United States", CodeName = "US" },
                new Survey { Id = 3, Name = "Ukraine", CodeName = "UA" }
            );
        }
    }
}
