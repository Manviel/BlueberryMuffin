using BlueberryMuffin.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class Question : BaseQuestion
    {
        public int Id { get; set; }

        [ForeignKey(nameof(SurveyId))]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public virtual ICollection<SurveyResponse> Responses { get; set; }
        public virtual ICollection<QuestionOption> Options { get; set; }
    }
}
