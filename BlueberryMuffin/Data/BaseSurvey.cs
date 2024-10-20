using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
{
    public abstract class BaseSurvey
    {
        [Required]
        public string Name { get; set; }
        public string CodeName { get; set; }
    }

    public class GetSurvey : BaseSurvey
    {
        public int Id { get; set; }
    }

    public class CreateSurvey : BaseSurvey
    {
    }

    public class SurveyDetails : GetSurvey
    {
        public IList<GetHotel> Hotels { get; set; }
    }
}
