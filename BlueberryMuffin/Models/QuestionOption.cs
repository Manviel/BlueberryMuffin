using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public class QuestionOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string OptionText { get; set; }

        public virtual Question Question { get; set; }
    }
}
