using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty(nameof(Question.Answers))]
        public virtual Question Question { get; set; }

        public int SurveyResponseId { get; set; }

        [ForeignKey(nameof(SurveyResponseId))]
        [InverseProperty(nameof(SurveyResponse.Answers))]
        public virtual SurveyResponse SurveyResponse { get; set; }

        public string TextAnswer { get; set; }
        public virtual ICollection<SelectedOption> SelectedOptions { get; set; }
    }
}
