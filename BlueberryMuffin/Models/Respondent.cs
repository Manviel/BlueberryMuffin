using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public enum RespondentStatus
    {
        Invited,
        Opened,
        Completed,
        Disabled
    }

    public class Respondent : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; }

        public RespondentStatus Status { get; set; }

        [Required]
        public Guid InvitationToken { get; set; } = Guid.NewGuid();
    }
}
