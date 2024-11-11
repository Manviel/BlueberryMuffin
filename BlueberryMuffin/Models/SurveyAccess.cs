using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class SurveyAccess
    {
        public int SurveyId { get; set; }
        public string UserId { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(SurveyId))]
        [InverseProperty(nameof(Survey.SurveyAccesses))]
        public virtual Survey Survey { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApiUser.SurveyAccesses))]
        public virtual ApiUser User { get; set; }
    }
}
