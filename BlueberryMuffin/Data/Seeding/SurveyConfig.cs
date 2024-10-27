using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlueberryMuffin.Models;

namespace BlueberryMuffin.Data.Seeding
{
    public class SurveyConfig : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasOne(s => s.CreatedBy)
                .WithMany(u => u.CreatedSurveys)
                .HasForeignKey(s => s.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
