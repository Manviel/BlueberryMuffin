using BlueberryMuffin.Data;

namespace BlueberryMuffin.Models
{
    public class SurveyAccess
    {
        public int SurveyId { get; set; }
        public string UserId { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

        public virtual Survey Survey { get; set; }
        public virtual ApiUser User { get; set; }
    }
}
