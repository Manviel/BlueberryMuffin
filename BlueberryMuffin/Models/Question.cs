using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class Question : BaseQuestion
    {
        [ForeignKey(nameof(SurveyId))]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public virtual ICollection<QuestionOption> Options { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
