using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
{
    public class CreateCountry
    {
        [Required]
        public string Name { get; set; }
        public string CodeName { get; set; }
    }
}
