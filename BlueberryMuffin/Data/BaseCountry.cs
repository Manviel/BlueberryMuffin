using System.ComponentModel.DataAnnotations;

namespace BlueberryMuffin.Data
{
    public abstract class BaseCountry
    {
        [Required]
        public string Name { get; set; }
        public string CodeName { get; set; }
    }
}
