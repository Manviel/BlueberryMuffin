using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class Question : BaseQuestion
    {
        public int SurveyId { get; set; }

        [ForeignKey(nameof(SurveyId))]
        public Survey Survey { get; set; }

        public virtual ICollection<QuestionOption> Options { get; set; }

        [InverseProperty(nameof(Answer.Question))]
        public virtual ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
    }
}
