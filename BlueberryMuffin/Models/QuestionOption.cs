using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public class QuestionOption : BaseEntity
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string OptionText { get; set; }

        public virtual Question Question { get; set; }
    }
}
