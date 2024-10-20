using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
{
    public abstract class BaseQuestion
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; }
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
