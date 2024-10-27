namespace BlueberryMuffin.Models
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int SurveyResponseId { get; set; }
        public virtual SurveyResponse SurveyResponse { get; set; }

        public string TextAnswer { get; set; }
        public virtual ICollection<SelectedOption> SelectedOptions { get; set; }
    }
}
