using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlueberryMuffin.Data.Relation
{
    public class SurveyAccessConfig : IEntityTypeConfiguration<SurveyAccess>
    {
        public void Configure(EntityTypeBuilder<SurveyAccess> builder)
        {
            builder.HasKey(sm => new { sm.SurveyId, sm.UserId });

            builder.HasOne(sm => sm.Survey)
                .WithMany(s => s.SurveyAccesses)
                .HasForeignKey(sm => sm.SurveyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sm => sm.User)
                .WithMany(u => u.SurveyAccesses)
                .HasForeignKey(sm => sm.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
