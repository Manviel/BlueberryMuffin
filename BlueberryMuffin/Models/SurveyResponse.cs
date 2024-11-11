using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(SurveyId))]
        [InverseProperty(nameof(Survey.Responses))]
        public virtual Survey Survey { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApiUser.SurveyResponses))]
        public virtual ApiUser User { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
