using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
{
    public enum QuestionType
    {
        Text,
        SingleChoice,
        MultipleChoice
    }

    public abstract class BaseQuestion
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public QuestionType Type { get; set; }
    }

    public abstract class BaseQuestionDetails : BaseQuestion
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SurveyId { get; set; }
    }

    public class GetQuestion : BaseQuestionDetails
    {
        public int Id { get; set; }
    }

    public class CreateQuestion : BaseQuestionDetails
    {
    }
}
