using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class Survey : BaseSurvey
    {
        public virtual IList<Question> Questions { get; set; } = new List<Question>();

        [InverseProperty(nameof(SurveyAccess.Survey))]
        public virtual ICollection<SurveyAccess> SurveyAccesses { get; set; } = new HashSet<SurveyAccess>();

        [InverseProperty(nameof(SurveyResponse.Survey))]
        public virtual ICollection<SurveyResponse> Responses { get; set; } = new HashSet<SurveyResponse>();
    }
}