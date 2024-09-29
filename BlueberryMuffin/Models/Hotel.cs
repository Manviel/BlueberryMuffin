using BlueberryMuffin.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class Hotel : BaseHotel
    {
        public int Id { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
