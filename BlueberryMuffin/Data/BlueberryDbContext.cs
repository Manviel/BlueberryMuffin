using BlueberryMuffin.Data.Relation;
using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueberryMuffin.Data
{
    public class BlueberryDbContext : IdentityDbContext<ApiUser>
    {
        public BlueberryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<SurveyAccess> SurveyAccesses { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SelectedOption> SelectedOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new SurveyConfig());
            modelBuilder.ApplyConfiguration(new SurveyAccessConfig());
            modelBuilder.ApplyConfiguration(new SurveyResponseConfig());
            modelBuilder.ApplyConfiguration(new QuestionConfig());
            modelBuilder.ApplyConfiguration(new AnswerConfig());
            modelBuilder.ApplyConfiguration(new SelectedOptionConfig());
        }
    }
}
