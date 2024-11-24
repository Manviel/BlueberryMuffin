using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class GetSurvey : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public abstract class BaseSurvey : GetSurvey
    {
        [Required]
        public string CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        [InverseProperty(nameof(ApiUser.CreatedSurveys))]
        public virtual ApiUser CreatedBy { get; set; }
    }

    public class SurveyDetails : BaseSurvey
    {
        public IList<GetQuestion> Questions { get; set; }
    }
}
