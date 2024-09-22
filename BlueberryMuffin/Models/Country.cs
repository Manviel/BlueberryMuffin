namespace BlueberryMuffin.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
    }
}