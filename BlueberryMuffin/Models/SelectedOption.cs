namespace BlueberryMuffin.Models
{
    public class SelectedOption : BaseEntity
    {
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        public int QuestionOptionId { get; set; }
        public virtual QuestionOption QuestionOption { get; set; }
    }
}
