using BlueberryMuffin.Data;

namespace BlueberryMuffin.Models
{
    public class Survey : BaseSurvey
    {
        public virtual IList<Question> Questions { get; set; }
        public virtual ICollection<ApiUser> Managers { get; set; }
        public virtual ICollection<Respondent> Respondents { get; set; }
    }
}