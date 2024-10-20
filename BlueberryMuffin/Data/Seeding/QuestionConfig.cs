using BlueberryMuffin.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data.Seeding
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                new Question { Id = 1, Name = "Courtleigh Question & Suites The", Address = "Kingston", SurveyId = 1, Rating = 4.5 },
                new Question { Id = 2, Name = "Hyatt Place New York City", Address = "New York", SurveyId = 2, Rating = 5 },
                new Question { Id = 3, Name = "ibis Lviv Center", Address = "Lviv", SurveyId = 3, Rating = 3.1 }
            );
        }
    }
}
