using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
{
    public abstract class BaseHotel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double? Rating { get; set; }
    }

    public abstract class BaseHotelDetails : BaseHotel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SurveyId { get; set; }
    }
}
