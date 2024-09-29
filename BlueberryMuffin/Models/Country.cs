using BlueberryMuffin.Data;

namespace BlueberryMuffin.Models
{
    public class Country : BaseCountry
    {
        public int Id { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
    }
}