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

    public class Respondent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int SurveyId { get; set; }
        [Required]
        public RespondentStatus Status { get; set; }
        public DateTime? InvitationSentAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        [Required]
        public Guid InvitationToken { get; set; } = Guid.NewGuid();

        public virtual Survey Survey { get; set; }
        public virtual ICollection<SurveyResponse> Responses { get; set; }
    }
}
