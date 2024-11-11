using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data.Relation
{
    public class SelectedOptionConfig : IEntityTypeConfiguration<SelectedOption>
    {
        public void Configure(EntityTypeBuilder<SelectedOption> builder)
        {
            builder.HasOne(so => so.Answer)
                .WithMany(a => a.SelectedOptions)
                .HasForeignKey(so => so.AnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(so => so.QuestionOption)
                .WithMany()
                .HasForeignKey(so => so.QuestionOptionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
