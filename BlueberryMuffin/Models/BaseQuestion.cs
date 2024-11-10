using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Models
{
    public enum QuestionType
    {
        Text,
        SingleChoice,
        MultipleChoice
    }

    public abstract class BaseQuestion : BaseEntity
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public QuestionType Type { get; set; }
    }

    public class GetQuestion : BaseQuestion
    {
    }
}
