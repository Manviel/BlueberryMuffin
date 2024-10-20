using BlueberryMuffin.Data;

namespace BlueberryMuffin.Models
{
    public class Survey : BaseSurvey
    {
        public int Id { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
    }
}