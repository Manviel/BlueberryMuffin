using BlueberryMuffin.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Data
{
    public abstract class BaseSurvey : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public virtual ApiUser CreatedBy { get; set; }
    }

    public class GetSurvey : BaseSurvey
    {
    }

    public class CreateSurvey : BaseSurvey
    {
    }

    public class SurveyDetails : GetSurvey
    {
        public IList<GetQuestion> Questions { get; set; }
    }
}
