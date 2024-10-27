using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data.Relation
{
    public class AnswerConfig : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.SurveyResponse)
                .WithMany(sr => sr.Answers)
                .HasForeignKey(a => a.SurveyResponseId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
