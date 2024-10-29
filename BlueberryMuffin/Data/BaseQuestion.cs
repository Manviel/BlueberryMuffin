using BlueberryMuffin.Models;
using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
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
