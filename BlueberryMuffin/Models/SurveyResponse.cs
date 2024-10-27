using BlueberryMuffin.Data;

namespace BlueberryMuffin.Models
{
    public enum ResponseStatus
    {
        Invited,
        Opened,
        Completed,
        Disabled
    }

    public class SurveyResponse : BaseEntity
    {
        public string UserId { get; set; }
        public int SurveyId { get; set; }
        public ResponseStatus Status { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ApiUser User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
