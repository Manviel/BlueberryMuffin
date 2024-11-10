namespace BlueberryMuffin.Models
{
    public class Survey : BaseSurvey
    {
        public virtual IList<Question> Questions { get; set; }
        public virtual ICollection<SurveyAccess> SurveyAccesses { get; set; }
        public virtual ICollection<SurveyResponse> Responses { get; set; }
    }
}