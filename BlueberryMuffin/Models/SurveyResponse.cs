using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public class SurveyResponse : BaseEntity
    {
        [Required]
        public int RespondentId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public string Response { get; set; }
        [Required]
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        
        public virtual Respondent Respondent { get; set; }
        public virtual Question Question { get; set; }
    }
}
