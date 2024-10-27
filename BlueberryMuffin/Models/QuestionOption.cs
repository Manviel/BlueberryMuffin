using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public class QuestionOption : BaseEntity
    {
        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Question Question { get; set; }
    }
}
