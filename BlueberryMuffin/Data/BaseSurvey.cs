using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Data
{
    public abstract class BaseSurvey
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string CreatedById { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CreatedById))]
        public virtual ApiUser CreatedBy { get; set; }
    }

    public class GetSurvey : BaseSurvey
    {
        public int Id { get; set; }
    }

    public class CreateSurvey : BaseSurvey
    {
    }

    public class SurveyDetails : GetSurvey
    {
        public IList<GetQuestion> Questions { get; set; }
    }
}
