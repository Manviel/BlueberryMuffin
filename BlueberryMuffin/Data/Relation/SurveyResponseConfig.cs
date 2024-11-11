using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data.Relation
{
    public class SurveyResponseConfig : IEntityTypeConfiguration<SurveyResponse>
    {
        public void Configure(EntityTypeBuilder<SurveyResponse> builder)
        {
            builder.HasOne(sr => sr.Survey)
                .WithMany(s => s.Responses)
                .HasForeignKey(sr => sr.SurveyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sr => sr.User)
                .WithMany(u => u.SurveyResponses)
                .HasForeignKey(sr => sr.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
